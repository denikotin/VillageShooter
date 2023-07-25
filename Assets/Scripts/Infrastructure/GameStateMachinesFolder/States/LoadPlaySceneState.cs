using Assets.Scripts.Data;
using Assets.Scripts.Data.Enums;
using Assets.Scripts.Data.StaticData;
using Assets.Scripts.Infrastructure.Services;
using Assets.Scripts.Infrastructure.Services.Builders;
using Assets.Scripts.Infrastructure.Services.GameControlServicefolder;
using Assets.Scripts.Infrastructure.Services.LevelServiceFolder;
using Assets.Scripts.Infrastructure.Services.SaveLoadServiceFolder;
using Assets.Scripts.Infrastructure.Services.SpawnServiceFolder;
using Assets.Scripts.Infrastructure.Services.StaticDataServiceFolder;
using Assets.Scripts.Logic.Enemies;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Infrastructure.GameStateMachinesFolder.States
{
    public class LoadPlaySceneState : IPayloadState
    {
        private GameStateMachine _gameStateMachine;
        private ServiceLocator _serviceLocator;
        private SceneLoader _sceneLoader;
        private Factory _factory;
        private GameControlService _gameControllService;
        private LevelService _levelService;
        private SpawnService _spawnService;
        private StaticDataService _staticDataService;
        private LevelStaticData _levelData;
        private SaveLoadService _saveLoadService;

        public LoadPlaySceneState(GameStateMachine gameStateMachine, ServiceLocator serviceLocator, SceneLoader sceneLoader)
        {
            _gameStateMachine = gameStateMachine;
            _serviceLocator = serviceLocator;
            _sceneLoader = sceneLoader; 
        }

        public void Enter(int level)
        {
            Debug.Log($"Entered {this.GetType().Name}");
            GetServices();
            GetLevelData(level);
            LoadScene();
        }

        public void Enter()
        {

        }
        public void Exit()
        {

        }
       

        private void GetServices()
        {
            _spawnService = _serviceLocator.GetService<SpawnService>();
            _staticDataService = _serviceLocator.GetService<StaticDataService>();
            _factory = _serviceLocator.GetService<Factory>();
            _gameControllService = _serviceLocator.GetService<GameControlService>();
            _levelService = _serviceLocator.GetService<LevelService>();
            _saveLoadService = _serviceLocator.GetService<SaveLoadService>();
        }
        private void GetLevelData(int level) => _levelData = _staticDataService.GetLevelStaticData(level);
        private void LoadScene()
        {
            _sceneLoader.LoadScene("Play", OnLoaded);
        }

        private void OnLoaded()
        {
            ConstructAudio();
            GameObject player = ConstructPlayer();
            _gameControllService.Construct(player);

            List<GameObject> enemies = ConstructEnemies();
            EnemyCounter counter = ConstructEnemyCounter(enemies);
            WinLoseGame winLosegame = ConstructWinLoseGame(counter);

            ConstructUI(player,counter,winLosegame);
        }

        #region Audio
        private GameObject ConstructAudio()
        {
            AudioBuilder audioMainMenuBuilder = _serviceLocator.GetService<AudioBuilder>();
            GameObject mainMenuAudio = audioMainMenuBuilder.Build(SceneID.Play);
            return mainMenuAudio;
        }

        #endregion

        #region Player
        private GameObject ConstructPlayer()
        {
            PlayerBuilder playerBuilder = _serviceLocator.GetService<PlayerBuilder>();
            return playerBuilder.Build();
        }
        #endregion

        #region Enemies
        private List<GameObject> ConstructEnemies()
        {
            List<GameObject> enemies = new List<GameObject>();
            
            SpawnPoint spawnPoint = GameObject.FindObjectOfType<SpawnPoint>();
            spawnPoint.Construct(_spawnService, _levelData);
            enemies.AddRange(spawnPoint.SpawnEnemies());

            if (_levelData.IsBoss)
            {
                BossSpawnPoint bossSpawnPoint = GameObject.FindObjectOfType<BossSpawnPoint>();
                bossSpawnPoint.Construct(_spawnService, _levelData);
                enemies.AddRange(bossSpawnPoint.SpawnEnemies());
            }

            return enemies;
        }
        #endregion

        #region EnemyCounter
        private EnemyCounter ConstructEnemyCounter(List<GameObject> enemies)
        {
            GameObject counterGo = _factory.Create(AssetPaths.ENEMY_COUNTER);
            EnemyCounter counter = counterGo.GetComponent<EnemyCounter>();
            counter.Construct(enemies);
            return counter;
        }
        #endregion

        #region WinLose
        private WinLoseGame ConstructWinLoseGame(EnemyCounter enemyCounter)
        {
            GameObject winLoseGo = _factory.Create(AssetPaths.WIN_LOSE_GAME);
            WinLoseGame winLoseGame = winLoseGo.GetComponent<WinLoseGame>();
            winLoseGame.Construct(_levelService,_saveLoadService,_gameControllService, enemyCounter);
            return winLoseGame;
        }
        #endregion

        #region UI
        private void ConstructUI(GameObject player, EnemyCounter enemyCounter, WinLoseGame winLoseGame)
        {
            GameObject root = ConstructRoot();
            GameObject hud = ConstructHUD(root, enemyCounter, winLoseGame);
        }

        private GameObject ConstructRoot()
        {
            UIRootBuilder uiRootBuilder = _serviceLocator.GetService<UIRootBuilder>();
            return uiRootBuilder.Build();
        }

        private GameObject ConstructHUD(GameObject root,EnemyCounter enemyCounter, WinLoseGame winLoseGame)
        {
            HUDBuilder hudBuilder = _serviceLocator.GetService<HUDBuilder>();
            hudBuilder.Initialize(root.transform, winLoseGame);
            GameObject hud = hudBuilder.Build();
            hudBuilder.BuildMainMenuButtons();
            hudBuilder.BuildPauseMenu();
            hudBuilder.BuildCounter(enemyCounter);

            return hud;
        }
        #endregion
    }
}
