﻿using Automation.Extension.Contracts;
using Newtonsoft.Json;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.Text;

namespace Automation.Extension.Components
{
    public class WebDriverFactory
    {
        private readonly DriversParams driverParam;
        public WebDriverFactory(string driverParamsJson)
            :this(LoadParam(driverParamsJson))
        {

        }
        public WebDriverFactory(DriversParams driversParam)
        {
            this.driverParam = driversParam;
            if (string.IsNullOrEmpty(driversParam.Binaries) || driversParam.Binaries == ".")//if user doesnt provide the 
            {                                                                               //then take drivers from current directory
                driversParam.Binaries = Environment.CurrentDirectory;
            }
        }

        //Local WebDrivers
        private IWebDriver GetChrome() => new ChromeDriver(driverParam.Binaries);
        private IWebDriver GetIE() => new InternetExplorerDriver(driverParam.Binaries);

        //Remote WebDrivers
        private IWebDriver GetRemoteChrome() => 
            new RemoteWebDriver(new Uri(driverParam.Binaries),new ChromeOptions());
        private IWebDriver GetRemoteIE() =>
    new RemoteWebDriver(new Uri(driverParam.Binaries), new InternetExplorerOptions());


        private static DriversParams LoadParam(string driverParamsJson)
        {
            if (string.IsNullOrEmpty(driverParamsJson))
            {
                return new DriversParams { Source = "Local", Driver = "Chrome", Binaries = "." };
            }
            return JsonConvert.DeserializeObject<DriversParams>(driverParamsJson);
        }
    }
}
