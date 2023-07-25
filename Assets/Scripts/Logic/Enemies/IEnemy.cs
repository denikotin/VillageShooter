using UnityEngine.AI;
using UnityEngine;
using Assets.Scripts.Logic.Enemies.AdventurerFolder;
using System;

namespace Assets.Scripts.Logic.Enemies
{
    public interface IEnemy
    {
        public event Action<IEnemy> OnEnemyDeath;
        public void Initialize(NavMeshAgent agent, EnemyController enemyController, AnimationController animationController);
        public void Follow(Transform target);
        public void Attack(PolygonFPSControler player);
        public void Die();
        public void TakeDamage(int value);
    }
}
