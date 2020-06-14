using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automation.API.Components
{
    public interface IStudentDetails
    {
        string LastName();
        string FirstName();
        DateTime EnrollmentDate();
    }
}
