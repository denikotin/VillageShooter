using Assets.Scripts.Logic.Weapons;
using System;
using UnityEngine;

namespace Assets.Scripts.Infrastructure.Services.GameControlServicefolder
{
    public class GameControlService : IService
    {
        public event Action OnGameStopped;
        public event Action OnGameContinue;

        private Weapon[] _weapons;

        public void Construct(GameObject player) => _weapons = player.GetComponentsInChildren<Weapon>();

        public void StopGame()
        {
            OnGameStopped?.Invoke();
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            Time.timeScale = 0;
            DisableWeapons();
        }

        public void ContinueGameForPlay()
        {
            OnGameContinue?.Invoke();
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            Time.timeScale = 1;
            EnableWeapons();
        }

        public void ContinueGame() => Time.timeScale = 1;

        private void DisableWeapons()
        {
            foreach (Weapon weapon in _weapons)
            {
                weapon.enabled = false;
            }
        }

        private void EnableWeapons()
        {
            foreach (Weapon weapon in _weapons)
            {
                weapon.enabled = true;
            }
        }
    }
}
