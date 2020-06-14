using Automation.API.Pages;
using Automation.Core.Components;
using Automation.Core.Logging;
using Automation.Core.Testing;
using Automation.Framework.UI.Pages;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automtion.Testing.Cases
{
    public class CreateStudent : TestCase
    {
        public override bool AutomationTest(IDictionary<string, object> testParams)
        {

            var keyword = testParams["keyword"];

            return new FluentUI(Driver)
                .ChangeContext<StudentsUI>($"{testParams["application"]}")
                .Create()
                .LastName("cSharp")
                .FirstName("student")
                .Create()
                .FindByName("")
                .students()
                .Any();
        }
    }
}
