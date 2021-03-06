﻿using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Forms;
using System.Collections.ObjectModel;
using System.Diagnostics;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

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
            timeWaiting = "";
        }
        public void CreateDriver(bool isHeadless)
        {

            var driverService = ChromeDriverService.CreateDefaultService();
            driverService.HideCommandPromptWindow = true;
            var options = new ChromeOptions();
            options.AddArgument("--incognito");
            options.AddArguments("--disable-extensions");
            options.AddArguments("--disable-application-cache");
            options.AddArgument("notifications");
            options.AcceptInsecureCertificates = true;
            this.Driver = new ChromeDriver(driverService, options);
            Driver.Manage().Window.Maximize();



        }
        /// <summary>
        /// chromedriver
        /// </summary>
        public ChromeDriver Driver { get; set; }
        private bool IsHeadLess { get; set; }
        public bool CloseWordList = false;
        public string timeWaiting;

        /// <summary>
        /// kiểm tra thông tin của 1 user
        /// </summary>
        /// <param name="user">userName+password</param>
        /// <returns>đúng khi có thể đăng nhập</returns>
        public bool CheckUserIsTrue(User user)
        {
            try
            {
                SignInFacebook(user);
                var trangChu = Driver.FindElementsByXPath("//a[@href='https://www.facebook.com/?ref=tn_tnmn']");
                Driver.Close();
                if (trangChu.Count == 0)
                {
                    return false;
                }

            }
            catch
            {
                Console.WriteLine("Loi kt tk");
            }
            return true;
        }

        public void SignInFacebook(User user)
        {

            CreateDriver(IsHeadLess);
            Console.WriteLine("SignInFb with user " + user);
            Driver.Navigate().GoToUrl("https://www.facebook.com/");
            Driver.FindElementByXPath("//input[@id='email']").SendKeys(user.UserName);
            Thread.Sleep(2000);
            Driver.FindElementByXPath("//input[@id='pass']").SendKeys(user.PassWord);
            Thread.Sleep(2000);
            Driver.FindElementByXPath("//input[@data-testid='royal_login_button']").Click();
            Thread.Sleep(1000);


        }

        #region kt thông báo
        private void PopMessengerNotification()
        {
            if (checkNotificationIsTrue())
            {
                PopMessengerNotification();
            }
            var xxxx = Driver.FindElementsByXPath("//div[@aria-label='Đánh dấu là đã đọc']/../../..//span[contains(text(), 'đã bình luận về bài viết của bạn')]/../../../../../../../../..//span");
            foreach (var item in xxxx)
            {
                var nn = item.GetAttribute("href");
                if (nn != null)
                    Console.WriteLine(nn);
            }
            xxxx[0].GetAttribute("href");
            var xxx = this.Driver.FindElementsByXPath("//div[@aria-label='Đánh dấu là đã đọc']/../../..//span[contains(text(), 'đã bình luận về bài viết của bạn')]/../../../../../../../../..| //div[@aria-label='Đánh dấu là đã đọc']/../../..//span[contains(text(), 'đã bình luận về ảnh của bạn')]/../../../../../../../../..|//div[@aria-label='Mark as Read']/../../..//span[contains(text(), 'commented on your photo')]/../../../../../../../../..|//div[@aria-label='Đánh dấu là đã đọc']/../../..//span[contains(text(), 'thích bài viết của bạn')]/../../../../../../../../..|//div[@aria-label='Mark as Read']/../../..//span[contains(text(), 'commented on your post')]/../../../../../../../../..");
            foreach (var yourCmt in xxx)
            {
                var xx = yourCmt.GetAttribute("href");
                yourCmt.Click();
            }

            ////div[contains(text(), 'phản hồi')]
            Thread.Sleep(3000);
        }

        private bool checkNotificationIsTrue()
        {
            try
            {
                var notification = Driver.FindElementByXPath("//span[@id='notificationsCountValue']");
                if (int.Parse(notification.Text) > 0)
                {
                    notification.Click();
                    Thread.Sleep(300);
                    return true;
                }
            }

            catch
            {
                return false;
            }
            return false;
        }
        #endregion 

        public void CloseAllDriver()
        {

            try
            {
                Driver.Close();
                Console.WriteLine("driver close ");
                foreach (Process p in Process.GetProcessesByName("chrome"))
                {
                    p.Kill();
                    Thread.Sleep(500);
                }
            }
            catch
            {
                Console.WriteLine("can not close chrome");
            }
        }
        public ListGroup GetAllGroup(User user)
        {
            SignInFacebook(user);
            Driver.Navigate().GoToUrl("https://www.facebook.com/groups/");
            Thread.Sleep(3000);
            while (true)
            {
                try
                {
                    var xx = Driver.FindElementsByXPath("//span[text()='See more...']");
                    if (xx.Count == 0)
                    {
                        xx = Driver.FindElementsByXPath("//span[text()='Xem thêm...']");
                        if (xx.Count == 0)
                        {
                            break;
                        }

                    }
                    xx[0].Click();
                }
                catch
                {
                    Console.WriteLine("Error:get al group"); Thread.Sleep(200);
                }
                Thread.Sleep(2000);
            }
            var groups = Driver.FindElementsByXPath("//a[@aria-current='false']");
            var listgroup = new ListGroup();
            foreach (var item in groups)
            {
                listgroup.ListG.Add(new Group(item.Text, item.GetAttribute("href")));
            }
            return listgroup;
        }

        /// <summary>
        /// thêm bài viết trong tát cả các group đã tham gia
        /// </summary>
        /// <param name="user">tài khoản fb</param>
        /// <param name="post">bài viết </param>
        public void PostInGroups(User user, Post post, List<Group> groups)
        {

            SignInFacebook(user);
            int dem = 0;
            foreach (var item in groups)
            {
                if (dem == 5)
                {
                    CloseAllDriver();
                    Thread.Sleep(180000);
                    dem = 0;
                    SignInFacebook(user);
                }
                Console.WriteLine("strat post post in " + item.Name);
                PostGroup(item.Href, post);
                if (CloseWordList)
                    return;
                dem++;
                Thread.Sleep(30000);
            }
        }
        public void PostInGroup(User user, Post post, string item)
        {
            SignInFacebook(user);
            PostGroup(item, post);
        }

        private void PostGroup(string item, Post post)
        {
            Console.WriteLine("chrome go to url= " + item);
            try
            {
                Driver.Navigate().GoToUrl(item);
                Thread.Sleep(2000);
                var write = Driver.FindElementsByXPath("//textarea[@placeholder='Write something...']|//textarea[@placeholder='Bạn viết gì đi...']");
                if (write.Count == 0)
                {
                    write = Driver.FindElementsByXPath("//input[@placeholder='What are you selling?']|//input[@placeholder='Bạn đang bán gì?'] ");
                    if (write.Count == 0)
                    {
                        throw new Exception("có nhóm mới");
                    }
                    //div[@aria-label="Mô tả mặt hàng của bạn (không bắt buộc)"]
                    else Groups_2(write, post);
                }
                else
                    Groups_1(write, post);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: post group " + ex);
            }
        }

        private void ClickNext()
        {
            MoveToElement(Driver.FindElementByXPath("//button[@data-testid='react-composer-post-button']"));
            Driver.FindElementByXPath("//button[@data-testid='react-composer-post-button']").Click();
            Thread.Sleep(3000);

        }
        int dem = 0;
        private void MoveToElement(IWebElement webElement)
        {
            Thread.Sleep(500);
            var actions = new Actions(Driver);
            actions.MoveToElement(webElement);
            Thread.Sleep(500);
            actions.Perform();
            Thread.Sleep(1000);
        }

        private void Groups_2(ReadOnlyCollection<IWebElement> write, Post post)
        {
            MoveToElement(write[0]);
            Thread.Sleep(2000);
            write[0].Click();
            if (CheckPostNumberLimited() == false)
            {
                Thread.Sleep(1000);
                Driver.FindElementByXPath("//input[@placeholder='What are you selling?']|//input[@placeholder='Bạn đang bán gì?'] ").SendKeys("miễn phí");
                Thread.Sleep(1000);
                SendImg(post.ImgPost.PathImgPost);
                Thread.Sleep(1000);
                Driver.FindElementByXPath("//input[@maxlength='20']").SendKeys("1");
                Thread.Sleep(1000);
                Driver.FindElementByXPath("//div[@aria-autocomplete='list']").SendKeys(post.TextPost.ToString());
                ClickNext();
                Thread.Sleep(500);
                checkedDiv();
                if (CloseWordList == true) return;
                Thread.Sleep(500);
                ClickNext();
                Console.WriteLine("post complete with Groups_2 " + "+ at" + DateTime.Now.ToString("h:mm:ss tt") + " bài viết đã đăng là " + dem);
                Thread.Sleep(10000);
            }
        }

        private bool CheckRobot()
        {
            if (Driver.FindElementsByXPath("//div[text()='Security Check']").Count != 0)
            {
                try
                {
                    Driver.FindElementByXPath("//a[text()='Cancel']").Click();
                    CloseWordList = true;
                    return true;
                }
                catch
                {
                    Console.WriteLine("Error can not close check robot ");
                    return true;
                }
            }
            else return false;
        }

        private void checkedDiv()
        {
            dem++;
            var divs = Driver.FindElementsByXPath("//div[@height='300']//div[@aria-checked='false']");
            foreach (var item in divs)
            {
                MoveToElement(item);
                item.Click();
                if (CheckRobot() == true)
                    return;
                dem++;

            }
        }

        private void Groups_1(ReadOnlyCollection<IWebElement> write, Post post)
        {
            MoveToElement(write[0]);
            Thread.Sleep(3000);
            write[0].Click();
            if (CheckPostNumberLimited() == false)
            {
                Thread.Sleep(500);
                SendImg(post.ImgPost.PathImgPost);
                Thread.Sleep(500);
                Driver.FindElementByXPath("//div[@aria-autocomplete='list']").SendKeys(post.TextPost);
                Thread.Sleep(1000);
                ClickNext();
                Thread.Sleep(10000);
                dem++;
                Console.WriteLine("post complete with Groups_1 " + "+ at" + DateTime.Now.ToString("h:mm:ss tt") + " số bài đã đăng là " + dem);
            }

        }

        private void SendImg(List<string> imgPost)
        {
            Thread.Sleep(1000);
            foreach (var item in imgPost)
            {
                Thread.Sleep(500);
                var img = Driver.FindElementsByXPath("//a[@class='__9u _47kt']");
                if (img.Count == 0)
                {
                    Thread.Sleep(500);
                    img = Driver.FindElementsByXPath("//div[@class='_3jk']");
                    if (img.Count == 0)
                    {
                        throw new Exception("phát sinh lỗi trong quá trình gửi ảnh -SendImg");
                    }
                }
                try
                {
                    MoveToElement(img[0]);
                    Thread.Sleep(3000);
                    img[0].Click();
                    Thread.Sleep(1000);
                    SendKeys.SendWait(item);
                    Thread.Sleep(1000);
                    SendKeys.SendWait(@"{Enter}");
                    Thread.Sleep(4000);
                }
                catch
                {
                    Console.WriteLine("Error: can not click send Img");
                }
            }

        }

        private bool CheckPostNumberLimited()
        {
            Thread.Sleep(1000);
            var numberpost = Driver.FindElementsByXPath("//h3");
            if (numberpost.Count == 8)
            {
                if (numberpost[7].Text == "You can't post right now")
                {
                    Console.WriteLine("Error: can not post post in group because number post is limited");
                    var time = Driver.FindElementByXPath("//b[contains(text(),'You can post again in ')]").Text;
                    var index = time.LastIndexOf("in") + 2;
                    this.timeWaiting = time.Substring(index, time.Length - 1 - index);
                    Driver.FindElementByXPath("//button[text()='This Is A Mistake']").Click();
                    Thread.Sleep(500);
                    Driver.FindElementByXPath("//a[text()='OK']").Click();
                    Thread.Sleep(500);
                    CloseWordList = true;
                    return true;
                }
            }
            CloseWordList = false;
            return false;
        }

        public void checkListUser(List<User> listUser)
        {
            foreach (var user in listUser)
            {
                user.CheckUserIsTrue = CheckUserIsTrue(user).ToString();
            }
        }
    }
}
