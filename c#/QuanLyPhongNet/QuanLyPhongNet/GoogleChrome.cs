using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using System.Collections.ObjectModel;
using System.Diagnostics;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace QuanLyPhongNet
{
    public class GoogleChrome
    {

        /// <summary>
        /// khởi tạo chrome
        /// </summary>
        /// <param name="isHeadless">==true chrome sẽ không hiển thị</param>
        public GoogleChrome()
        {
            CreateDriver();
        }
        private void CreateDriver()
        {
            try
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
            catch
            {
                Console.WriteLine("Error: can not create chrome");
            }

        }
        /// <summary>
        /// chromedriver
        /// </summary>
        public ChromeDriver Driver { get; set; }
        public bool IsHeadLess { get; private set; }
        private void MoveToElement(IWebElement webElement)
        {
            Thread.Sleep(500);
            var actions = new Actions(Driver);
            actions.MoveToElement(webElement);
            Thread.Sleep(500);
            actions.Perform();
            Thread.Sleep(1000);
            webElement.Click();
            Thread.Sleep(1000);
        }

        public void GetAllRam()
        {
            var list = new List<Ram>();
            GetInforRam("https://phongvu.vn/ram", list, new List<string>(), new List<string>());
            Driver.Close();
        }
        int dem = 0;
        public void GetInforRam(string url, List<Ram> list, List<string> listString, List<string> listUrl)
        {
            if (listString.Contains(url))
                return;
            listString.Add(url);

            Driver.Navigate().GoToUrl(url);
            dem++;
            Thread.Sleep(1000);
            try
            {
                MoveToElement(Driver.FindElementByXPath("//span[text()='Đọc thêm']/.."));
                var thuocTinhIweb = Driver.FindElementsByXPath("//div[@class='attribute-content']//p");

                if (thuocTinhIweb.Count() < 10)
                    thuocTinhIweb = Driver.FindElementsByXPath("//div[text()='Thông tin chi tiết']/..//td");
                var dic = GetDic(thuocTinhIweb);

                list.Add(new Ram(dic));
                var listHref = Driver.FindElementsByXPath("//*[contains(@href,'bo-nho') ]");
                foreach (var item in listHref)
                    if (!listUrl.Contains(item.GetAttribute("href")))
                        listUrl.Add(item.GetAttribute("href"));
                foreach (var item in listUrl)
                {
                    GetInforRam(item, list, listString, listUrl);
                }
            }
            catch
            {
            }
            if (list.Count >= 100)
            {

            }
        }

        private List<string> GetLinhKien(List<string> thuocTinhRam, Dictionary<string, string> dic)
        {
            var res = new List<string>();
            foreach (var thuocTinh in thuocTinhRam)
            {
                res.Add(dic[thuocTinh]);
            }
            return res;
        }

        private Dictionary<string, string> GetDic(ReadOnlyCollection<IWebElement> thuocTinhIweb)
        {
            var dic = new Dictionary<string, string>();
            for (int i = 0; i < thuocTinhIweb.Count; i += 2)
            {
                dic.Add(thuocTinhIweb[i].Text, thuocTinhIweb[i + 1].Text);
            }
            return dic;
        }
    }
}

