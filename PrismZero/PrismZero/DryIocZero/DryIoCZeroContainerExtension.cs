using System;
using System.Diagnostics;
using System.Linq;
using DryIocZero;
using Prism.Ioc;

namespace PrismZero.DryIocZero
{
    public class DryIocZeroContainerExtension : IContainerExtension<IZeroContainer>
    {
        public IZeroContainer Instance { get; }

        public DryIocZeroContainerExtension(IZeroContainer container)
        {
            Instance = container;
        }

        private object ResolveFromStaticContainer(Type type, string key = null)
        {
            Debug.WriteLine($"Resolving {type} ({key}) from static container");

            return Instance.Resolve(type, key);
        }

        private object ResolveFromStaticContainerWithParameters(Type type, object[] parameters, string key = null)
        {
            Debug.WriteLine($"Resolving {type} ({key}) from static container with parameters: {String.Join(", ", parameters)}");

            return Instance.Resolve(type,
                key,
                args: parameters);
        }

        private bool IsRegisteredInStatic(Type type, string key = null)
        {
            return Instance.IsRegistered(type, key);
        }

        public object Resolve(Type type)
        {
            return ResolveFromStaticContainer(type);
        }

        public object Resolve(Type type, string name)
        {
            return ResolveFromStaticContainer(type, name);
        }

        public object Resolve(Type type, params (Type Type, object Instance)[] parameters)
        {
            var ps = parameters.Select(x => x.Instance).ToArray();

            return ResolveFromStaticContainerWithParameters(type, ps);
        }

        public object Resolve(Type type, string name, params (Type Type, object Instance)[] parameters)
        {
            var ps = parameters.Select(x => x.Instance).ToArray();

            return ResolveFromStaticContainerWithParameters(type, ps, name);
        }

        private void RegisterInstanceInStaticPlaceholder(Type type, object instance, string key = null)
        {
            Debug.WriteLine($"Registering {instance} as {type} ({key}) into static placeholder");

            Instance.RegisterDelegate(type, _ => instance, serviceKey: key);
        }

        public IContainerRegistry RegisterInstance(Type type, object instance)
        {
            RegisterInstanceInStaticPlaceholder(type, instance);

            return this;
        }

        public IContainerRegistry RegisterInstance(Type type, object instance, string name)
        {
            RegisterInstanceInStaticPlaceholder(type, instance);

            return this;
        }

        public IContainerRegistry RegisterSingleton(Type from, Type to)
        {
            throw new NotImplementedException("This implementation allows runtime registration of instances and delegates only.");
        }

        public IContainerRegistry RegisterSingleton(Type from, Type to, string name)
        {
            throw new NotImplementedException("This implementation allows runtime registration of instances and delegates only.");
        }

        public IContainerRegistry Register(Type from, Type to)
        {
            throw new NotImplementedException("This implementation allows runtime registration of instances and delegates only.");
        }

        public IContainerRegistry Register(Type from, Type to, string name)
        {
            throw new NotImplementedException("This implementation allows runtime registration of instances and delegates only.");
        }

        public bool IsRegistered(Type type)
        {
            var ret = Instance.IsRegistered(type);

            Debug.WriteLine($"Returning {ret} for IsRegistered({type})");

            return ret;
        }

        public bool IsRegistered(Type type, string name)
        {
            var ret = Instance.IsRegistered(type, name);

            Debug.WriteLine($"Returning {ret} for IsRegistered({type}, {name})");

            return ret;
        }

        public void FinalizeExtension()
        {

        }
    }
}
