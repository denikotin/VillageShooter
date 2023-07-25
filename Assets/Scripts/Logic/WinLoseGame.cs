using Assets.Scripts.Infrastructure.Services.GameControlServicefolder;
using Assets.Scripts.Infrastructure.Services.LevelServiceFolder;
using Assets.Scripts.Infrastructure.Services.SaveLoadServiceFolder;
using Assets.Scripts.Logic.Enemies;
using System.Collections;
using UnityEngine;

public class WinLoseGame : MonoBehaviour
{
    private EnemyCounter _enemyCounter;
    private PolygonFPSControler _player;
    private LevelService _levelService;
    private SaveLoadService _saveLoadService;


    public void Construct(LevelService levelService,SaveLoadService saveLoadService,GameControlService gameControl, EnemyCounter enemyCounter)
    {
        _levelService = levelService;
        _saveLoadService = saveLoadService;
        _enemyCounter = enemyCounter;
        _player = FindObjectOfType<PolygonFPSControler>();
        _player.OnPlayerDeath += LoseGame;
    }

    public void Start()
    {
        _enemyCounter.OnAllEnemiesDieEvent += WinGame;
        Yandex.instance.OnAdvCloseEvent += StartNextLvl;
    }

    private void LoseGame()
    {
        _levelService.RestartLevel();
    }

    private void WinGame()
    {
        _levelService.CompleteCurrentLevel();
        _levelService.OpenNextLevel();
        _saveLoadService.Save();
        StartCoroutine(StartNextLevelRoutine());
    }

    private IEnumerator StartNextLevelRoutine()
    {
        Time.timeScale = 0.3f;
        Time.fixedDeltaTime = 0.02F * Time.timeScale;
        yield return new WaitForSeconds(0.4f);
        Time.timeScale = 1f;
        Time.fixedDeltaTime = 0.02F * Time.timeScale;

        if (Yandex.instance.IsAdvReady())
        {
            Yandex.instance.ShowAdv();
        }
        else
        {
            StartNextLvl();
        }

    }

    private void StartNextLvl() 
    {
        _levelService.StartNextLevel();
    }


}
