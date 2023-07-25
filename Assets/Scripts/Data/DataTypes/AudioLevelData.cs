using System;

namespace Assets.Scripts.Data.DataTypes
{
    [Serializable]
    public class AudioLevelData
    {
        public float Sound;
        public float Music;

        public AudioLevelData(AudioLevel audioLevel) 
        {
            Sound = audioLevel.Sound;
            Music = audioLevel.Music;
        }
    }
}
