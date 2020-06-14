using Automation.API.Pages;
using Automation.Core.Components;
using Automation.Core.Logging;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automtion.Framework.UI.Pages
{
    public class CreateStudentUI : FluentUI, ICreateStudent
    {
        public CreateStudentUI(IWebDriver driver) 
            : base(driver) { }

        public CreateStudentUI(IWebDriver driver, ILogger logger)
            : base(driver, logger) { }

        public IStudents BackToList()
        {
            throw new NotImplementedException();
        }

        public IStudents Create()
        {
            throw new NotImplementedException();
        }

        public ICreateStudent EnrollmentDate(DateTime dateTime)
        {
            throw new NotImplementedException();
        }

        public DateTime EnrollmentDate()
        {
            throw new NotImplementedException();
        }

        public ICreateStudent FirstName(string firstName)
        {
            throw new NotImplementedException();
        }

        public string FirstName()
        {
            throw new NotImplementedException();
        }

        public ICreateStudent LastName(string lastName)
        {
            throw new NotImplementedException();
        }

        public string LastName()
        {
            throw new NotImplementedException();
        }
    }
}
