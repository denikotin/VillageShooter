using Assets.Scripts.Data;
using Assets.Scripts.Data.Enums;
using UnityEngine;

namespace Assets.Scripts.Infrastructure.Services.SpawnServiceFolder
{
    public class SpawnService:IService
    {
        private readonly Factory _factory;

        public SpawnService(Factory factory)
        {
            _factory = factory;
        }

        public GameObject Spawn(EnemyID enemy, Vector3 position)
        {
            return _factory.Create(GetEnemy(enemy),position);
        }

        private string GetEnemy(EnemyID enemy)
        {
            switch (enemy)
            {
                case EnemyID.Toilet:
                    return AssetPaths.SIMPLE_TOILET;
                case EnemyID.BossToilet:
                    return AssetPaths.BOSS_TOILET;
                default:
                    return null;
            }

        }
    }
}
