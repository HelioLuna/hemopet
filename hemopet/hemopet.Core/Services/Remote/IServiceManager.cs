﻿using hemopet.Core.Services.Remote.Example;
using System;
using System.Collections.Generic;
using System.Text;

namespace hemopet.Core.Services.Remote
{
    public interface IServiceManager
    {
        IExampleService ExampleService { get; }
    }
}