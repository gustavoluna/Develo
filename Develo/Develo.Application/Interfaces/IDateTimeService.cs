﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Develo.Application.Interfaces
{
    public interface IDateTimeService
    {
        DateTime NowUtc { get; }
    }
}
