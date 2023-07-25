using UnityEngine;
using Assets.Scripts.Data;
using Assets.Scripts.Data.DataTypes;
using Assets.Scripts.Logic.UI.Buttons;
using Assets.Scripts.Infrastructure.Services.ProgressServiceFolder;
using Assets.Scripts.Infrastructure.GameStateMachinesFolder;
using Assets.Scripts.Infrastructure.Services.LevelServiceFolder;

namespace Assets.Scripts.Infrastructure.Services.Builders
{
    public class UIMainMenuBuilder: IBuilder
    {
        private Transform _root;
        private Factory _factory;
        private WindowService _windowService;
        private ProgressService _progressService;
        private GameStateMachine _gameStateMachine;
        private LevelService _levelService;
        private BackgroundAudio _backgroundAudio;

        public UIMainMenuBuilder(ServiceLocator serviceLocator)
        {
            _factory = serviceLocator.GetService<Factory>();
            _windowService = serviceLocator.GetService<WindowService>();
            _progressService = serviceLocator.GetService<ProgressService>();
            _gameStateMachine = serviceLocator.GetService<GameStateMachine>();
            _levelService = serviceLocator.GetService<LevelService>();
        }

        public void Initialize(Transform root, GameObject mainMenuAudio)
        {
            _root = root;
            _backgroundAudio = mainMenuAudio.GetComponentInChildren<BackgroundAudio>();
        }

        public GameObject Build()
        {
            GameObject mainMenu = _factory.Create(AssetPaths.MAIN_MENU, _root.transform);

            ConstructButtons(mainMenu);
            ConstructAudioSliders(mainMenu);
            ConstructWindows(mainMenu);

            return mainMenu;
        }

        private void ConstructButtons(GameObject mainMenu)
        {
            foreach (OpenButton button in mainMenu.GetComponentsInChildren<OpenButton>())
            {
                button.Construct(_windowService);
            }

            foreach(StartLevelButton startButton in mainMenu.GetComponentsInChildren<StartLevelButton>())
            {
                startButton.Construct(_levelService);
                startButton.Initialize();
            }
        }

        private void ConstructWindows(GameObject mainMenu)
        {
            WindowBase[] windows = mainMenu.GetComponentsInChildren<WindowBase>();

            foreach (WindowBase window in windows)
            {
                window.Construct(_windowService);
                _windowService.Close(window.gameObject);    
            }
        }

        private void ConstructAudioSliders(GameObject mainMenu)
        {
            AudioOptionsWindow audioWindow = mainMenu.GetComponentInChildren<AudioOptionsWindow>();
            audioWindow.Construct(_backgroundAudio);
            AudioLevelData audioLevelData = _progressService.GetProgress().AudioLevel;
            audioWindow.SoundSlider.value = audioLevelData.Sound;
            audioWindow.MusicSlider.value = audioLevelData.Music;
        }
    }
}
