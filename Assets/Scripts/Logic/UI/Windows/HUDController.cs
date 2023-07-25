using Assets.Scripts.Infrastructure.Services.GameControlServicefolder;
using Assets.Scripts.Logic.UI;
using Assets.Scripts.Logic.UI.CounterFolder;
using System;
using UnityEngine;

public class HUDController : MonoBehaviour
{
    [SerializeField] private PauseMenu _pauseMenu;
    [SerializeField] private CounterUI _counter;


    private bool _isOpened = false;
    private GameControlService _gameControlService;

    public event Action OnGamePaused;
    public event Action OnGameContinue;

    public void Construct(GameControlService gameControlService, WinLoseGame winLoseGame)
    {
        _gameControlService = gameControlService;
    }

    private void Start()
    {
        _pauseMenu.gameObject.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            _isOpened = !_isOpened;
            if (_isOpened)
            {
                PauseGame();
            }
            else
            {
                ContinueGame();
            }
        }
    }

    public void ContinueGame()
    {
        OnGameContinue?.Invoke();
        _pauseMenu.gameObject.SetActive(false);
        _gameControlService.ContinueGameForPlay();

    }

    private void PauseGame()
    {
        _pauseMenu.gameObject.SetActive(true);
        OnGamePaused?.Invoke();
        _gameControlService.StopGame();
    }

}
