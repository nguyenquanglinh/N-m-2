using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using OpenQA.Selenium;
using System.Collections.ObjectModel;

namespace ToolFacebook
{
    public class GoogleChrome
    {

        /// <summary>
        /// khởi tạo chrome
        /// </summary>
        /// <param name="isHeadless">==true chrome sẽ không hiển thị</param>
        public GoogleChrome(bool isHeadless)
        {
            this.IsHeadLess = isHeadless;
        }
        public void CreateDriver(bool isHeadless)
        {
            var driverService = ChromeDriverService.CreateDefaultService();
            driverService.HideCommandPromptWindow = true;
            var options = new ChromeOptions();
            options.AddArgument("--incognito");
            options.AcceptInsecureCertificates = true;
            if (isHeadless == true)
                options.AddArgument("headless");
            this.Driver = new ChromeDriver(driverService, options);
            Driver.Manage().Window.Maximize();

        }
        /// <summary>
        /// chromedriver
        /// </summary>
        public ChromeDriver Driver { get; set; }
        private bool IsHeadLess { get; set; }

        /// <summary>
        /// kiểm tra thông tin của 1 user
        /// </summary>
        /// <param name="user">userName+password</param>
        /// <returns>đúng khi có thể đăng nhập</returns>
        public bool CheckUser(User user)
        {
            SignInFacebook(user);
            var CheckeUser = Driver.FindElementsByXPath("//a[text()='Khôi phục tài khoản của bạn']");
            Driver.Close();
            if (CheckeUser.Count != 0)
            {
                return false;
            }
            return true;
        }

        public void SignInFacebook(User user)
        {
            CreateDriver(IsHeadLess);
            Driver.Navigate().GoToUrl("https://www.facebook.com/");
            Driver.FindElementByXPath("//input[@id='email']").SendKeys(user.UserName);
            Driver.FindElementByXPath("//input[@id='pass']").SendKeys(user.PassWord);
            Driver.FindElementByXPath("//input[@data-testid='royal_login_button']").Click();
            Thread.Sleep(5000);
        }



        public List<string> GetAllGroup(User user)
        {
            SignInFacebook(user);
            Driver.Navigate().GoToUrl("https://www.facebook.com/groups/");
            Thread.Sleep(10000);
            while (true)
            {
                var xx = Driver.FindElementsByXPath("//span[text()='See more...']");
                if (xx.Count == 0)
                {
                    break;
                }

                xx[0].Click();
                Thread.Sleep(2000);
            }
            var groups = Driver.FindElementsByXPath("//a[@aria-current='false']");
            var listgroup = new List<string>();
            foreach (var item in groups)
            {
                listgroup.Add(item.GetAttribute("href"));
            }
            return listgroup;
        }

        /// <summary>
        /// thêm bài viết trong tát cả các group đã tham gia
        /// </summary>
        /// <param name="user">tài khoản fb</param>
        /// <param name="post">bài viết </param>
        public void PostInGroups(User user, Post post)
        {
            int dem = 0;
            var xx = GetAllGroup(user);
            foreach (var item in xx)
            {
                if (dem == 4)
                {
                    Driver.Close();
                    SignInFacebook(user);
                    dem = 0;
                }
                PostGroup(item, post);
                dem++;
                Thread.Sleep(18000);
            }
        }

        public void PostInGroup(User user, Post post, string item)
        {
            SignInFacebook(user);
            PostGroup(item, post);
        }

        private void PostGroup(string item, Post post)
        {
            Driver.Navigate().GoToUrl(item);
            var write = Driver.FindElementsByXPath("//textarea[@placeholder='Write something...']");
            if (write.Count == 0)
            {
                write = Driver.FindElementsByXPath("//input[@placeholder='What are you selling?'] ");
                if (write.Count == 0)
                {
                    write = Driver.FindElementsByXPath("//textarea[@placeholder='Bạn viết gì đi...']");
                    if (write.Count == 0)
                    {
                        write = Driver.FindElementsByXPath("//input[@placeholder='Bạn đang bán gì?'] ");
                        if (write.Count == 0)
                        {
                            throw new Exception("phát sinh lỗi khi có thêm 1 group khác");
                        }
                        else Groups_2(write, post);
                    }
                    else Groups_1(write, post);
                }
                else
                    Groups_2(write, post);
            }
            else
                Groups_1(write, post);
        }


        private void ClickNext()
        {
            MoveToElement(Driver.FindElementByXPath("//button[@data-testid='react-composer-post-button']"));
            Thread.Sleep(5000);
            Driver.FindElementByXPath("//button[@data-testid='react-composer-post-button']").Click();
        }

        private void MoveToElement(IWebElement webElement)
        {
            var actions = new Actions(Driver);
            actions.MoveToElement(webElement);
            actions.Perform();
            Thread.Sleep(2000);
        }
        private void Groups_2(ReadOnlyCollection<IWebElement> write, Post post)
        {
            MoveToElement(write[0]);
            write[0].Click();
            Thread.Sleep(1000);
            SendImg(post.ImgPost);
            Driver.FindElementByXPath("//input[@maxlength='20']").SendKeys("1");

            if (Driver.FindElementsByXPath("//input[@placeholder='What are you selling?'] ").Count != 0)
            {
                Driver.FindElementByXPath("//input[@placeholder='What are you selling?'] ").SendKeys(post.TextPost);
            }
            else
            {
                if (Driver.FindElementsByXPath("//input[@placeholder='Bạn đang bán gì?'] ").Count != 0)
                {
                    Driver.FindElementByXPath("//input[@placeholder='Bạn đang bán gì?'] ").SendKeys(post.TextPost);
                }
                else
                {
                    throw new Exception("phát sinh lỗi ở group 2 trong quá trình tìm thanh text");
                }
            }
            ClickNext();
            ClickNext();
        }

        private void Groups_1(ReadOnlyCollection<IWebElement> write, Post post)
        {

            MoveToElement(write[0]);
            write[0].Click();
            SendImg(post.ImgPost);
            Driver.FindElementByXPath("//div[@aria-autocomplete='list']").SendKeys(post.TextPost);
            ClickNext();
        }

        private void SendImg(List<string> imgPost)
        {
            Thread.Sleep(3000);
            foreach (var item in imgPost)
            {
                var img = Driver.FindElementsByXPath("//a[@class='__9u _47kt']");
                if (img.Count == 0)
                {
                    img = Driver.FindElementsByXPath("//div[@class='_3jk']");
                    if (img.Count == 0)
                    {
                        throw new Exception("phát sinh lỗi trong quá trình gửi ảnh -SendImg");
                    }
                }

                MoveToElement(img[0]);
                img[0].Click();
                Thread.Sleep(3000);
                SendKeys.SendWait(item);
                Thread.Sleep(1000);
                SendKeys.SendWait(@"{Enter}");

                Thread.Sleep(1000);
            }
            Thread.Sleep(3000);
        }

        public void checkListUser(List<User> listUser)
        {
            foreach (var user in listUser)
            {
                user.CheckUserIsTrue = CheckUser(user).ToString();
            }
        }
    }
}
