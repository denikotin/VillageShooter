using Assets.Scripts.Logic.Enemies.AdventurerFolder;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Logic.Enemies
{
    public class EnemyCounter:MonoBehaviour
    {
        public event Action<int> OnEnemyDieEvent;
        public event Action OnAllEnemiesDieEvent;

        private List<GameObject> _enemies = new List<GameObject>();
        private int _startEnemyCount;


       public void Construct(List<GameObject> enemies)
        {
            _enemies = enemies;
            _startEnemyCount = _enemies.Count;

        }

        private void Start()
        {
            foreach (GameObject enemy in _enemies)
            {
                enemy.GetComponent<EnemyController>().SubscribeOnEnemyDeath(OnEnemyDie);
            }
        }


        public void OnEnemyDie(IEnemy enemy)
        {
            _enemies.RemoveAt(0);
            if(GetEnemyCount() == 0)
            {
                OnAllEnemiesDieEvent?.Invoke();
            }
            OnEnemyDieEvent?.Invoke(GetEnemyCount());
            
        }

        public int GetStartEnemyCount() => _startEnemyCount;

        private int GetEnemyCount() => _enemies.Count;
    }

}
