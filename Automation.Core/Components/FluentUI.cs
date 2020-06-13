using Automation.Core.Logging;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automation.Core.Components
{
    public abstract class FluentUI : IFluent
    {
        public IWebDriver Driver { get; }
        public ILogger Logger { get; }

        protected FluentUI(IWebDriver driver) 
            : this(driver, new TraceLogger()) {  }

        protected FluentUI(IWebDriver driver, ILogger logger)
        {
            Driver = driver;
            Logger = logger;
        }
        public T ChangeContext<T>()
        {
            var instance = Create<T>(null);
            Logger.Debug($"Instance of [{GetType()?.FullName}] created");
            return instance;
        }
        public T ChangeContext<T>(ILogger logger)
        {
            var instance = Create<T>(logger);
            Logger.Debug($"Instance of [{GetType()?.FullName}] created");
            return instance;
        }
        public T ChangeContext<T>(string application)
        {
            Driver.Navigate().GoToUrl(application);
            Driver.Manage().Window.Maximize();
            return Create<T>(null);
        }
        public T ChangeContext<T>(string application, ILogger logger)
        {
            Driver.Navigate().GoToUrl(application);
            Driver.Manage().Window.Maximize();
            return Create<T>(logger);
        }
        private T Create<T>(ILogger logger)
        {
            return logger==null?
                  (T)Activator.CreateInstance(typeof(T), new object[] { Driver, logger })
                : (T)Activator.CreateInstance(typeof(T), new object[] { Driver });
        }
    }
}
