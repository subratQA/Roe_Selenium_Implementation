using Automation.API.Components;
using Automation.Core.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automation.API.Pages
{
    public interface IStudents : IFluent, IPageNavigator<IStudents>,IMenu,ICreate<ICreateStudent>
    {
        IStudents FindByName(string name);
        IEnumerable<IStudent> students();
    }
}
