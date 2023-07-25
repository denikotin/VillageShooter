using Assets.Scripts.Infrastructure.EntryPoint;
using Assets.Scripts.Logic.UI.LoadingScreenFolder;
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.Infrastructure.Services
{
    public class SceneLoader : IService
    {
        private ICoroutineRunner _coroutineRunner;
        private LoadingScreen _loadingScreen;

        public SceneLoader(ICoroutineRunner coroutineRunner, LoadingScreen loadingScreen)
        {
            _coroutineRunner = coroutineRunner;
            _loadingScreen = loadingScreen;  
        }

        public void LoadScene(string sceneName, Action OnLoaded = null) => _coroutineRunner.StartCoroutine(LoadSceneRoutine(sceneName, OnLoaded));

        private IEnumerator LoadSceneRoutine(string sceneName, Action OnLoaded = null)
        {
            _loadingScreen.Show();
            AsyncOperation loadScene = SceneManager.LoadSceneAsync(sceneName);

            while (!loadScene.isDone)
            {
                yield return null;
            }

            OnLoaded?.Invoke();
            _loadingScreen.Hide();
        }
    }
}
