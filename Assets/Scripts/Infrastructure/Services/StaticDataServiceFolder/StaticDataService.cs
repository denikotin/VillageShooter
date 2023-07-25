using Assets.Scripts.Data;
using Assets.Scripts.Data.StaticData;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.Scripts.Infrastructure.Services.StaticDataServiceFolder
{
    public class StaticDataService: IService
    {
        private AudioStaticData _audioStaticData;
        private Dictionary<int, LevelStaticData> _levelStaticData;


        public void Load()
        {
            _audioStaticData = Resources.Load<AudioStaticData>(AssetPaths.AUDIO_STATIC_DATA);
            _levelStaticData = Resources.LoadAll<LevelStaticData>(AssetPaths.LEVEL_STATIC_DATA).ToDictionary(x => x.LevelNumber, x => x);

        }

        public AudioStaticData GetAudioStaticData()
        {
            return _audioStaticData;
        }

        public LevelStaticData GetLevelStaticData(int levelNumber) => _levelStaticData[levelNumber];

    }
}
