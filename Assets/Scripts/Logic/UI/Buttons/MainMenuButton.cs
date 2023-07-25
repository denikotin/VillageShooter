using Assets.Scripts.Infrastructure.GameStateMachinesFolder;
using Assets.Scripts.Infrastructure.GameStateMachinesFolder.States;
using Assets.Scripts.Infrastructure.Services.GameControlServicefolder;

namespace Assets.Scripts.Logic.UI.Buttons
{
    public class MainMenuButton:ButtonBase
    {
        private GameControlService _gameControlService;
        private GameStateMachine _gameStateMachine;

        private new void Awake()
        {
            base.Awake();
            _button.onClick.AddListener(LoadMainMenu);
            _button.onClick.AddListener(Yandex.instance.ShowAdv);
        }

        public void Construct(GameStateMachine gameStateMachine, GameControlService gameControlService)
        {
            _gameControlService = gameControlService;
            _gameStateMachine = gameStateMachine;
        }

        private void LoadMainMenu()
        {
            _gameControlService.ContinueGame();
            _gameStateMachine.EnterState<LoadMainMenuState>();
        }
    }
}
