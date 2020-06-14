using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automation.API.Components
{
    public interface IEntityAction
    {
        object Edit();
        object Details();
        object Delete();
    }
}
