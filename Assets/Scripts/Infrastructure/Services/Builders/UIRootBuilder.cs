using Assets.Scripts.Data;
using UnityEngine;

namespace Assets.Scripts.Infrastructure.Services.Builders
{
    public class UIRootBuilder : IBuilder
    {
        private Factory _factory;

        public UIRootBuilder(Factory factory)
        {
            _factory = factory;
        }

        public GameObject Build()
        {
            GameObject uiRoot =  _factory.Create(AssetPaths.UI_ROOT);
            return uiRoot;  
        }
    }
}
