using Automation.Core.Logging;
using Automation.Extension.Components;
using Automation.Extension.Contracts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automation.Core.Testing
{
    public abstract class TestCase
    {
        //fields
        private IDictionary<string, object> testParams;
        private int attempts;
        private ILogger logger;


        //properties
        public bool Actual { get; private set; }
        public IWebDriver Driver { get; private set; }

        //initialize all the fields
        protected TestCase()
        {
            testParams = new Dictionary<string, object>();
            attempts = 1;
            logger = new TraceLogger();
        }
        //components
        public abstract bool AutomationTest(IDictionary<string, object> testParams);
        public TestCase Execute()
        {
            Driver = Get();
            for (int i = 0; i < attempts; i++)
            {
                try
                {
                    Actual = AutomationTest(testParams);
                    if (Actual)
                    {
                        break;
                    }
                    logger.Debug($"[{GetType()?.FullName}] Failed at attempt [{i+1}]");
                }
                catch (AssertInconclusiveException ex)
                {
                    logger.Debug(ex, ex.Message);
                    break;
                }
                catch(NotImplementedException ex)
                {
                    logger.Debug(ex, ex.Message);
                    break;
                }
                catch (Exception ex)
                {
                    logger.Debug(ex, ex.Message);
                    break;
                }
                finally
                {
                    Driver?.Close();
                    Driver?.Dispose();
                }
            }
            return this; 
        }


        //Configurations
        public TestCase WithTestParams(IDictionary<string, object> testParams)
        {
            this.testParams = testParams;
            return this;
        }
        public TestCase WithNumberOfAttempts(int numberOfAttempts)
        {
            attempts = numberOfAttempts;
            return this;
        }
        public TestCase WithLogger(ILogger logger)
        {
            this.logger = logger;
            return this;
        }

        private IWebDriver Get()
        {
            //constants
            const string DRIVER = "driver";

            //deafults
            var driverParams = new DriversParams { Binaries = ".", Driver = "CHROME",Source="" };

            //change driver if exists
            if (testParams?.ContainsKey(DRIVER) == true)
            {
                driverParams.Driver = $"{testParams[DRIVER]}";
            }
            //Create driver if driver key not exist
            return new WebDriverFactory(driverParams).Get();
        }
    }
}
