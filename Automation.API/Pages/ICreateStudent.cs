using Automation.API.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automation.API.Pages
{
    public interface ICreateStudent : IStudentDetails, ICreate<IStudents>,IBack<IStudents>
    {
        ICreateStudent LastName(string lastName);
        ICreateStudent FirstName(string firstName);
        ICreateStudent EnrollmentDate(DateTime dateTime);
    }
}
