using Assets.Scripts.Data;
using UnityEngine;

namespace Assets.Scripts.Infrastructure.Services.Builders
{
    public class PlayerBuilder : IBuilder
    {
        private Factory _factory;

        public PlayerBuilder(ServiceLocator serviceLocator)
        {
            _factory = serviceLocator.GetService<Factory>();
        }

        public GameObject Build()
        {
            GameObject player =  _factory.Create(AssetPaths.PLAYER);
            player.transform.position = new Vector3(0f, 1f, 0f);
            return player;
        }
    }
}
