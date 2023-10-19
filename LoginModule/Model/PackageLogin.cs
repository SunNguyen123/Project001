using System;
using System.Collections.Generic;
using Prism.Events;
using Prism.Services;

namespace LoginModule.Model
{
    public class PackageLogin:PubSubEvent<(string,string)>
    {
    }
}
