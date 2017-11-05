using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PocketClone.Config
{
    public class Locator
    {
        public static IContainer Container { get; set; } = BuildDefaultContainer();

        private static IContainer BuildDefaultContainer()
        {
            var builder = new ContainerBuilder();
            builder.RegisterModule<AppModule>();
            return builder.Build();
        }
    }
}
