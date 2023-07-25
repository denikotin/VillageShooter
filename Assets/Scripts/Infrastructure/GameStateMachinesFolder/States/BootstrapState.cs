using UnityEngine;
using Assets.Scripts.Infrastructure.Services;
using Assets.Scripts.Infrastructure.Services.ProgressServiceFolder;
using Assets.Scripts.Infrastructure.Services.StaticDataServiceFolder;
using Assets.Scripts.Infrastructure.Services.SaveLoadServiceFolder;
using Assets.Scripts.Infrastructure.Services.SpawnServiceFolder;
using Assets.Scripts.Infrastructure.Services.Builders;
using Assets.Scripts.Infrastructure.Services.GameControlServicefolder;
using Assets.Scripts.Infrastructure.Services.LevelServiceFolder;

namespace Assets.Scripts.Infrastructure.GameStateMachinesFolder.States
{
    public class BootstrapState : IState
    {
        private SceneLoader _sceneLoader;
        private ServiceLocator _serviceLocator;
        private GameStateMachine _gameStateMachine;

        public BootstrapState(GameStateMachine gameStateMachine, ServiceLocator serviceLocator, SceneLoader sceneLoader)
        {
            _gameStateMachine = gameStateMachine;
            _serviceLocator = serviceLocator;
            _sceneLoader = sceneLoader;
        }

        public void Enter()
        {
            Debug.Log($"Entered {this.GetType().Name}");
            RegisterServices();
            InitializeServices();
            _gameStateMachine.EnterState<LoadProgressState>();
        }



        public void Exit()
        {
            
        }

        private void RegisterServices()
        {
            _serviceLocator.RegisterService<GameStateMachine>(_gameStateMachine);
            _serviceLocator.RegisterService<SceneLoader>(_sceneLoader);
            _serviceLocator.RegisterService<Factory>(new Factory());  
            _serviceLocator.RegisterService<WindowService>(new WindowService());
            _serviceLocator.RegisterService<ProgressService>(new ProgressService());
            _serviceLocator.RegisterService<SaveLoadService>(new SaveLoadService(_serviceLocator.GetService<ProgressService>()));
            _serviceLocator.RegisterService<StaticDataService>(new StaticDataService());
            _serviceLocator.RegisterService<SpawnService>(new SpawnService(_serviceLocator.GetService<Factory>()));
            _serviceLocator.RegisterService<GameControlService>(new GameControlService());
            _serviceLocator.RegisterService<LevelService>(new LevelService(_serviceLocator));

            _serviceLocator.RegisterService<AudioBuilder>(new AudioBuilder(_serviceLocator));
            _serviceLocator.RegisterService<UIRootBuilder>(new UIRootBuilder(_serviceLocator.GetService<Factory>()));
            _serviceLocator.RegisterService<UIMainMenuBuilder>(new UIMainMenuBuilder(_serviceLocator));
            _serviceLocator.RegisterService<HUDBuilder>(new HUDBuilder(_serviceLocator));
            _serviceLocator.RegisterService<PlayerBuilder>(new PlayerBuilder(_serviceLocator));
        }

        private void InitializeServices()
        {
            Yandex.instance.GetLanguage();
            Yandex.instance.GetDomain();

            Debug.Log(Yandex.instance.Language);
            Debug.Log(Yandex.instance.Domain);
        }
    }
}
