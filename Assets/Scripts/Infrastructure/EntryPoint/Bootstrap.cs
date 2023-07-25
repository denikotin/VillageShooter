using Assets.Scripts.Infrastructure.EntryPoint;
using Assets.Scripts.Logic.UI.LoadingScreenFolder;
using UnityEngine;

public class Bootstrap : MonoBehaviour, ICoroutineRunner
{
    [SerializeField] LoadingScreen _loadingScreen; 
    private Game _game;


    private void Awake()
    {
        RunGame();

        DontDestroyOnLoad(gameObject);
    }

    private void RunGame()
    {
        _game = new Game(this, _loadingScreen);
        _game.Run();
    }


}
