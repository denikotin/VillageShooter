using Assets.Scripts.Infrastructure.GameStateMachinesFolder;
using Assets.Scripts.Infrastructure.GameStateMachinesFolder.States;
using Assets.Scripts.Infrastructure.Services;
using Assets.Scripts.Logic.UI.LoadingScreenFolder;

namespace Assets.Scripts.Infrastructure.EntryPoint
{
    public class Game
    {
        private SceneLoader _sceneLoader;
        private ServiceLocator _serviceLocator;
        private GameStateMachine _gameStateMachine;

        public Game(ICoroutineRunner coroutineRunner, LoadingScreen loadingScreen)
        {
            _serviceLocator = new ServiceLocator();
            _sceneLoader = new SceneLoader(coroutineRunner, loadingScreen);
            _gameStateMachine = new GameStateMachine(_sceneLoader, _serviceLocator);
        }

        public void Run() => _gameStateMachine.EnterState<BootstrapState>();
    }
}
