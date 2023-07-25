using Assets.Scripts.Data;
using Assets.Scripts.Data.Enums;
using Assets.Scripts.Infrastructure.Services.ProgressServiceFolder;
using Assets.Scripts.Infrastructure.Services.StaticDataServiceFolder;
using UnityEngine;

namespace Assets.Scripts.Infrastructure.Services.Builders
{
    public class AudioBuilder : IAudioBuilder
    {
        private Factory _factory;
        private StaticDataService _staticDataService;
        private ProgressService _progressService;

        public AudioBuilder(ServiceLocator serviceLocator ) 
        {
            _factory = serviceLocator.GetService<Factory>();
            _staticDataService = serviceLocator.GetService<StaticDataService>();
            _progressService = serviceLocator.GetService<ProgressService>();
        }

        public GameObject Build(SceneID sceneID)
        {
            GameObject mainMenuAudio = _factory.Create(AssetPaths.MUSIC);

            BackgroundAudio mainMenuBckrAudio = mainMenuAudio.GetComponent<BackgroundAudio>();
            mainMenuBckrAudio.Construct(_progressService);
            mainMenuBckrAudio.SetMusic(GetMusic(sceneID));
            mainMenuBckrAudio.GetMusic().Play();

            return mainMenuAudio;
        }

        public GameObject Build()
        {
            return null;
        }

        private AudioClip GetMusic(SceneID sceneID)
        {
            switch (sceneID)
            {
                case SceneID.MainMenu:
                    return _staticDataService.GetAudioStaticData().MainMenuSceneMusic;
                case SceneID.Play:
                    return _staticDataService.GetAudioStaticData().MainMenuSceneMusic;
                default:
                    return null;
            }
        }
    }
}
