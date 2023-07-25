using UnityEngine;

namespace Assets.Scripts.Data.StaticData
{
    [CreateAssetMenu(fileName ="LevelStaticData", menuName ="StaticData/LevelStaticData")]
    public class LevelStaticData:ScriptableObject
    {
        public int LevelNumber;
        public bool IsBoss;
        public int EnemiesCount;
        public int BossCount;
    }
}
