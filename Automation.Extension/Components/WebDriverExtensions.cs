using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Internal;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;

namespace Automation.Extension.Components
{
    public static class WebDriverExtensions
    {
        public static IWebDriver GoToUrl(this IWebDriver driver, string url)
        {
            //Actions - initializng the driver, updating the driver instance
            driver.Navigate().GoToUrl(url);
            driver.Manage().Window.Maximize();

            //Fluents - returning the updated driver instance
            return driver;
        }
        public static IWebElement GetElement(this IWebDriver driver, By by, TimeSpan timeSpan)
        {
            var wait = new WebDriverWait(driver, timeSpan);
            return wait.Until(d => d.FindElement(by));  //search until the element found or timeout exception
        }
        public static IWebElement GetElement(this IWebDriver driver, By by) 
            => GetElement(driver, by, TimeSpan.FromSeconds(20));    //Extended method with default timeout of 20 sec
        public static SelectElement AsSelect(this IWebElement element)
            => new SelectElement(element);

        public static ReadOnlyCollection<IWebElement> GetElements(this IWebDriver driver, By by, TimeSpan timeSpan)
        {
            var wait = new WebDriverWait(driver, timeSpan);
            return wait.Until(d => d.FindElements(by));  //search until the element found or timeout exception
        }
        public static ReadOnlyCollection<IWebElement> GetElements(this IWebDriver driver, By by)
           => GetElements(driver, by, TimeSpan.FromSeconds(20));
        public static IWebElement GetVisibleElement(this IWebDriver driver, By by, TimeSpan timeSpan)
        {
            var wait = new WebDriverWait(driver, timeSpan);
            return wait.Until(d =>
            {
                var element = d.FindElement(by);
                return element.Displayed ? element : null;
            });
        }
        public static IWebElement GetVisibleElement(this IWebDriver driver, By by)
            => GetVisibleElement(driver, by, TimeSpan.FromSeconds(20));

        public static ReadOnlyCollection<IWebElement> GetVisibleElements(this IWebDriver driver, By by, TimeSpan timeSpan)
        {
            var wait = new WebDriverWait(driver, timeSpan);
            return wait.Until(d =>
            {
                var elements = d.FindElements(by).Where(i => i.Displayed).ToList();
                return new ReadOnlyCollection<IWebElement>(elements);
            });
        }
        public static ReadOnlyCollection<IWebElement> GetVisibleElements(this IWebDriver driver, By by)
            => GetVisibleElements(driver, by, TimeSpan.FromSeconds(20));

        public static IWebElement GetEnableElement(this IWebDriver driver, By by, TimeSpan timeSpan)
        {
            var wait = new WebDriverWait(driver, timeSpan);
            return wait.Until(d =>
            {
                var element = d.FindElement(by);
                return element.Enabled ? element : null;
            });
        }
        public static IWebElement GetEnableElement(this IWebDriver driver, By by)
            => GetEnableElement(driver, by, TimeSpan.FromSeconds(20));
        public static IWebDriver VerticalWindowScroll(this IWebDriver driver, int scrollAmount)
        {
            ((IJavaScriptExecutor)driver).ExecuteScript($"window.scroll(0,{scrollAmount});");
            return driver;
        }
        public static Actions Actions(IWebElement element)
        {
            var driver = ((IWrapsDriver)element).WrappedDriver;
            var actions = new Actions(driver);
            return actions.MoveToElement(element);
        }
        public static IWebElement ForceClick(IWebElement element)
        {
            var driver = ((IWrapsDriver)element).WrappedDriver;
            var executor = (IJavaScriptExecutor)driver;
            executor.ExecuteScript("arguments[0].click();", element);
            return element;
        }    
        public static IWebElement SendKeysWithInterval(this IWebElement element, string text, int interval)
        {
            foreach (var @char in text)
            {
                element.SendKeys("{@char}");
                Thread.Sleep(interval);
            }
            return element;
        }
        public static IWebElement ForceClear(this IWebElement element)
        {
            var value = element.GetAttribute("value");
            element.SendKeys(Keys.End);//Sends the cursor to end of the text
            for (int i = 0; i < value.Length; i++)
            {
                element.SendKeys(Keys.Backspace);
                Thread.Sleep(100);
            }
            return element;
        }


    }
}
