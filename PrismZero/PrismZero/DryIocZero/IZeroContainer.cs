using System;
using System.Collections.Generic;
using System.Text;
using DryIocZero;

namespace PrismZero.DryIocZero
{
    // we include an interface for the container so that our project
    // still builds even if the container hasn't been generated
    public interface IZeroContainer : IRegistrator, IResolverContext
    {
        void RegisterPageTypes();
        bool IsRegistered(Type type, object key = null);
    }
}
