using System;
using System.Collections.Generic;

namespace Assets.Scripts.Infrastructure.Services
{
    public class ServiceLocator:IService
    {
        private Dictionary<Type, IService> _services = new Dictionary<Type, IService>();


        public void RegisterService<TService>(TService service) where TService: IService
        {
            if (_services.ContainsKey(typeof(TService)))
            {
                throw new Exception($"Service Locator have already had service {typeof(TService)} ");
            }
            _services[typeof(TService)] = service;
        }

        public TService GetService<TService>() where TService: IService
        {
            if (!_services.ContainsKey(typeof(TService)))
            {
                throw new Exception($"Service Locator has no service {typeof(TService)}");
            }
            return (TService)_services[typeof(TService)];
        }
    }
}
