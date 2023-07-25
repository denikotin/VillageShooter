using Assets.Scripts.Infrastructure.Services.StaticDataServiceFolder;
using UnityEngine;

namespace Assets.Scripts.Data.StaticData
{
    [CreateAssetMenu(fileName ="AudioStaticData", menuName ="StaticData/AudioStaticData")]
    public class AudioStaticData: ScriptableObject
    {
        public float DefaultSoundVolume;
        public float DefaultMusicVolume;
        public AudioClip MainMenuSceneMusic;
        public AudioClip PlaySceneMusic;
    }
}
