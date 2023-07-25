using Assets.Scripts.Data.DataTypes;
using Assets.Scripts.Data.StaticData;
using Assets.Scripts.Infrastructure.Services;
using Assets.Scripts.Infrastructure.Services.LevelServiceFolder;
using Assets.Scripts.Infrastructure.Services.ProgressServiceFolder;
using Assets.Scripts.Infrastructure.Services.SaveLoadServiceFolder;
using Assets.Scripts.Infrastructure.Services.StaticDataServiceFolder;
using System;

namespace Assets.Scripts.Infrastructure.GameStateMachinesFolder.States
{
    public class LoadProgressState : IState
    {
        private readonly GameStateMachine _gameStateMachine;
        private readonly ServiceLocator _serviceLocator;
        private StaticDataService _staticDataService;
        private SaveLoadService _saveLoadService;
        private ProgressService _progressService;
        private LevelService _levelService;

        public LoadProgressState(GameStateMachine gameStateMachine, ServiceLocator serviceLocator)
        {
            _gameStateMachine = gameStateMachine;
            _serviceLocator = serviceLocator;

        }

        public void Enter()
        {
            GetServices();
            LoadStaticData();
            LoadProgress();
            LoadLevels();
            _gameStateMachine.EnterState<LoadMainMenuState>();
        }

        public void Exit()
        {

        }

        private void GetServices()
        {
            _staticDataService = _serviceLocator.GetService<StaticDataService>();
            _saveLoadService = _serviceLocator.GetService<SaveLoadService>();
            _progressService = _serviceLocator.GetService<ProgressService>();
            _levelService = _serviceLocator.GetService<LevelService>();
        }

        private void LoadStaticData()
        {
            _staticDataService.Load();
        }

        private void LoadProgress()
        {
            PlayerProgress progress = _saveLoadService.Load();
            if(progress == null)
            {
                AudioStaticData audio = _staticDataService.GetAudioStaticData();
                AudioLevel audioLevel = new AudioLevel(audio.DefaultSoundVolume, audio.DefaultMusicVolume);

                progress = new PlayerProgress(audioLevel,50);
            }
            _progressService.SetProgress(progress); 
        }

        private void LoadLevels()
        {
            _levelService.Initialize();
        }
    }
}
