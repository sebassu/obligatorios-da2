﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Services
{
    interface IFlowServices
    {
        int AddNewFlowFromData(List<string> flowDataToAdd);
    }
}
