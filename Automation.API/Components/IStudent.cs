using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automation.API.Components
{
    public interface IStudent
    {
        string LastName();
        string FirstName();
        DateTime EnrollmentDate();
        object Edit();
        object Details();
        object Delete();

    }
}
