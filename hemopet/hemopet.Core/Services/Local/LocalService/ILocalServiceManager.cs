using hemopet.Core.Services.Local.Example;
using System;
using System.Collections.Generic;
using System.Text;

namespace hemopet.Core.Services.Local
{
    public interface ILocalServiceManager
    {
        IExampleLocalService ExampleLocalService { get; }
    }
}
