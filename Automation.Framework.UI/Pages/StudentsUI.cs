using Automation.API.Components;
using Automation.API.Pages;
using Automation.Core.Components;
using Automation.Core.Logging;
using Automation.Extension.Components;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automation.Framework.UI.Pages
{
    public class StudentsUI : FluentUI, IStudents
    {
        public StudentsUI(IWebDriver driver)
            : base(driver) { }

        public StudentsUI(IWebDriver driver, ILogger logger)
            : base(driver, logger) { }

        public ICreateStudent Create()
        {
            throw new NotImplementedException();
        }

        public int CurrentPage()
        {
            throw new NotImplementedException();
        }

        public IStudents FindByName(string name)
        {
            Driver.GetEnableElement(By.XPath("//input[@id='SearchString']")).SendKeys(name);
            Driver.SubmitForms(0);
            return this;
        }

        public T Menu<T>(string menuItem)
        {
            throw new NotImplementedException();
        }

        public IStudents Next()
        {
            throw new NotImplementedException();
        }

        public IStudents Previous()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IStudent> students()
        {
            throw new NotImplementedException();
        }

        public int TotalPages()
        {
            throw new NotImplementedException();
        }
    }
}
