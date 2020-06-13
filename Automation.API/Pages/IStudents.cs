﻿using Automation.API.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automation.API.Pages
{
    public interface IStudents:IPageNavigator<IStudents>,IMenu
    {
        IStudents FindByName(string name);
        IEnumerable<IStudent> students();
    }
}
