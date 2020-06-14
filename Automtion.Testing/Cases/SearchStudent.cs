using Automation.API.Components;
using Automation.API.Pages;
using Automation.Core.Components;
using Automation.Core.Testing;
using Automation.Extension.Components;
using Automation.Extension.Contracts;
using Automation.Framework.UI.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automtion.Testing.Cases
{
    public class SearchStudent : TestCase
    {
        public override bool AutomationTest(IDictionary<string, object> testParams)
        {
            
            var keyword = testParams["keyword"];

            return new FluentUI(Driver)
                .ChangeContext<StudentsUI>($"{testParams["application"]}")
                .FindByName("")
                .students()
                .All(i => i.FirstName().Equals(keyword) || i.LastName().Equals(keyword));
        }
    }
}
