﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Doctrina.Core.Persistence.Models;
using Doctrina.xAPI.Models;

namespace Doctrina.Core.Services
{
    public interface IActivityService
    {
        ActivityEntity MergeActivity(Activity target);
    }
}
