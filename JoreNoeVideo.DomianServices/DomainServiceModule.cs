using System;
using System.Collections.Generic;
using System.Text;
using Autofac;
namespace JoreNoeVideo.DomainServices
{
    public class DomainServiceModule : Module
    {
        public DomainServiceModule(ContainerBuilder builder)
        {
        }
        protected override void Load(ContainerBuilder builder)
        {


            builder.RegisterAssemblyTypes(this.ThisAssembly)
            .Where(t => t.Name.EndsWith("DomainService"))
            .AsImplementedInterfaces();
        }
    }
}
