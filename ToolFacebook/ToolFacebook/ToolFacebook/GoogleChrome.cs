using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

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
        void CreateDriver(bool isHeadless)
        {
            var driverService = ChromeDriverService.CreateDefaultService();
            driverService.HideCommandPromptWindow = true;
            var options = new ChromeOptions();
            options.AddArgument("--incognito");
            if (isHeadless == true)
                options.AddArgument("headless");
            this.Driver = new ChromeDriver(driverService, options);
        }
        /// <summary>
        /// chromedriver
        /// </summary>
        public ChromeDriver Driver { get; set; }
        private bool IsHeadLess { get;  set; }

        /// <summary>
        /// kiểm tra thông tin của 1 user
        /// </summary>
        /// <param name="user">userName+password</param>
        /// <returns>đúng khi có thể đăng nhập</returns>
        public bool CheckUser(User user)
        {
            CreateDriver(IsHeadLess);
            Driver.Navigate().GoToUrl("https://www.facebook.com/");
            Driver.FindElementByXPath("//input[@id='email']").SendKeys(user.UserName);
            Driver.FindElementByXPath("//input[@id='pass']").SendKeys(user.PassWord);
            Driver.FindElementByXPath("//input[@data-testid='royal_login_button']").Click();
            var CheckeUser = Driver.FindElementsByXPath("//a[text()='Khôi phục tài khoản của bạn']");
            Thread.Sleep(15000);
            Driver.Close();
            if (CheckeUser.Count != 0)
            {
                return false;
            }
            return true;
        }
        public void checkListUser(List<User> listUser)
        {
            foreach(var user in listUser)
            {
                user.CheckUserIsTrue=CheckUser(user).ToString();
            }
        }
    }
}
