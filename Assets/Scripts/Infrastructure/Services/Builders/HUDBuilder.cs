using UnityEngine;
using Assets.Scripts.Data;
using Assets.Scripts.Logic.UI;
using Assets.Scripts.Logic.UI.Buttons;
using Assets.Scripts.Infrastructure.GameStateMachinesFolder;
using Assets.Scripts.Infrastructure.Services.GameControlServicefolder;
using Assets.Scripts.Logic.Enemies;
using Assets.Scripts.Logic.UI.CounterFolder;
using Assets.Scripts.Infrastructure.Services.LevelServiceFolder;

namespace Assets.Scripts.Infrastructure.Services.Builders
{
    public class HUDBuilder : IBuilder
    {
        public GameObject HUD { get; private set; }
        public HUDController Controller { get; private set; }
        public PauseMenu PauseMenu { get; private set; }

        private Transform _root;
        private Factory _factory;
        private WinLoseGame _winLoseGame;
        private GameStateMachine _gameStateMachine;
        private LevelService _levelService;
        private GameControlService _gameControlService;

        public HUDBuilder(ServiceLocator serviceLocator)
        {
            _factory = serviceLocator.GetService<Factory>();
            _gameControlService = serviceLocator.GetService<GameControlService>();
            _gameStateMachine = serviceLocator.GetService<GameStateMachine>();
            _levelService = serviceLocator.GetService<LevelService>();
        }

        public void Initialize(Transform root,WinLoseGame winLoseGame)
        {
            _root = root;
            _winLoseGame = winLoseGame;
        }

        public GameObject Build()
        {
            HUD = _factory.Create(AssetPaths.HUD,_root);
            Controller = HUD.GetComponent<HUDController>();
            Controller.Construct(_gameControlService, _winLoseGame);
            return HUD; 
        }

        public void BuildCounter(EnemyCounter enemyCounter)
        {
            HUD.GetComponentInChildren<CounterUI>().Construct(enemyCounter);
        }

        public void BuildMainMenuButtons()
        {
            MainMenuButton[] mainMenuButton = HUD.GetComponentsInChildren<MainMenuButton>();
            foreach (MainMenuButton button in mainMenuButton)
            {
                button.Construct(_gameStateMachine, _gameControlService);
            }
        }


        public void BuildPauseMenu() 
        {
            ContinueGameButton continueGameButton = HUD.GetComponentInChildren<ContinueGameButton>();
            continueGameButton.Construct(Controller);
        }
    }
}
