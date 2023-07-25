using Assets.Scripts.Data.Enums;
using Assets.Scripts.Infrastructure.Services;
using Assets.Scripts.Infrastructure.Services.Builders;
using UnityEngine;

namespace Assets.Scripts.Infrastructure.GameStateMachinesFolder.States
{
    public class LoadMainMenuState : IState
    {

        private ServiceLocator _serviceLocator;
        private SceneLoader _sceneLoader;


        public LoadMainMenuState(GameStateMachine gameStateMachine, ServiceLocator serviceLocator, SceneLoader sceneLoader)
        {
            _serviceLocator = serviceLocator;
            _sceneLoader = sceneLoader;
        }

        public void Enter()
        {
            Debug.Log($"Entered {this.GetType().Name}");
            LoadScene();
        }

        public void Exit()
        {

        }


        private void LoadScene() => _sceneLoader.LoadScene("MainMenu", OnLoaded);

        private void OnLoaded()
        {
            GameObject mainMenuAudio = ConstructAudio();
            ConstructUI(mainMenuAudio);

            Yandex.instance.ShowAdv();
        }

        #region Audio
        private GameObject ConstructAudio()
        {
            AudioBuilder audioMainMenuBuilder = _serviceLocator.GetService<AudioBuilder>();
            GameObject mainMenuAudio = audioMainMenuBuilder.Build(SceneID.MainMenu);
            return mainMenuAudio;
        }

        #endregion

        #region UI
        private void ConstructUI(GameObject mainMenuAudio)
        {
            GameObject root = ConstructRoot();
            ConstructMainMenu(root, mainMenuAudio);
        }

        private GameObject ConstructRoot()
        {
            UIRootBuilder uiBuilder = _serviceLocator.GetService<UIRootBuilder>();
            GameObject root = uiBuilder.Build();
            return root;
        }

        private void ConstructMainMenu(GameObject root, GameObject mainMenuAudio)
        {
            UIMainMenuBuilder uiMainMenuBuilder = _serviceLocator.GetService<UIMainMenuBuilder>();
            uiMainMenuBuilder.Initialize(root.transform, mainMenuAudio);
            uiMainMenuBuilder.Build();
        }
        #endregion
    }
}
