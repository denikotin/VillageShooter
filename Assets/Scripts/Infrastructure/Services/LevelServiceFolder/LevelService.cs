using Assets.Scripts.Data.DataTypes;
using Assets.Scripts.Infrastructure.GameStateMachinesFolder.States;
using Assets.Scripts.Infrastructure.GameStateMachinesFolder;
using Assets.Scripts.Infrastructure.Services.ProgressServiceFolder;
using System.Collections.Generic;
using System.Linq;


namespace Assets.Scripts.Infrastructure.Services.LevelServiceFolder
{
    public class LevelService:IService
    {
        private Dictionary<int, Level> _levels;
        private ProgressService _progressService;
        private GameStateMachine _gameStateMachine;
        private Level _currentLevel;

        public LevelService(ServiceLocator serviceLocator)
        {

            _progressService = serviceLocator.GetService<ProgressService>();
            _gameStateMachine = serviceLocator.GetService<GameStateMachine>();
        }

        public void Initialize()
        {
            GetLevelData();
        }

        public void StartLevel(int levelNumber)
        {
            if (IsLevelOpen(levelNumber))
            {
                _currentLevel = _levels[levelNumber];
                _gameStateMachine.EnterState<LoadPlaySceneState>(levelNumber);
            }
        }

        public void StartNextLevel()
        {
            if (_levels[_currentLevel.LevelNumber + 1].LevelNumber < 50)
            {
                _currentLevel = _levels[_currentLevel.LevelNumber + 1];
                _gameStateMachine.EnterState<LoadPlaySceneState>(_currentLevel.LevelNumber);
            }
        }

        public void OpenNextLevel()
        {
            if (_levels[_currentLevel.LevelNumber+1].LevelNumber < 50)
            {
                _levels[_currentLevel.LevelNumber + 1].IsOpen = true;
            }
        }

        public void CompleteCurrentLevel() => _currentLevel.IsCompleted = true;

        public void RestartLevel() => _gameStateMachine.EnterState<LoadPlaySceneState>(_currentLevel.LevelNumber);

        public void OpenLevel(int levelNumber) => _levels[levelNumber].IsOpen = true;

        public void CompleteLevel(int levelNumber) => _levels[levelNumber].IsCompleted = true;

        public bool IsLevelOpen(int levelNumber) => _levels[levelNumber].IsOpen;

        public bool IsLevelCompleted(int levelNumber) => _levels[levelNumber].IsCompleted;

        private void GetLevelData()
        {
            _levels = _progressService.GetLevelProgressData().Levels.ToDictionary(x => x.LevelNumber, x => x);
        }


    }
}
