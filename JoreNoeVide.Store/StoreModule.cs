using System;
using System.Collections.Generic;
using System.Text;
using Autofac;
namespace JoreNoeVideo.Store
{
    public class StoreModule:Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterGeneric(typeof(DbContextFace<>)).As(typeof(IDbContextFace<>));
        }
    }
}
