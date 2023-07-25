using Assets.Scripts.Infrastructure.EntryPoint;
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;

namespace Assets.Scripts.Logic.Enemies.AdventurerFolder
{
    public class BossToilet : IEnemy
    {
        public event Action<IEnemy> OnEnemyDeath;

        private NavMeshAgent _agent;
        private EnemyController _enemyController;
        private AnimationController _animationController;
        private readonly ICoroutineRunner _coroutineRunner;

        protected float _health;
        private bool _isAttacking;
        protected float _damage;


        public BossToilet(ICoroutineRunner coroutineRunner)
        {
            _coroutineRunner = coroutineRunner;
        }

        public void Initialize(NavMeshAgent agent, EnemyController enemyController, AnimationController animationController)
        {
            _agent = agent;


            _animationController = animationController;
            _enemyController = enemyController;

            _health = 1000;
        }

        public void Attack(PolygonFPSControler player)
        {
            if (!_isAttacking)
            {
                _coroutineRunner.StartCoroutine(AttackRoutine(player));
            }
        }

        public void Die()
        {
            OnEnemyDeath?.Invoke(this);
            _health = 0;
            UnityEngine.Object.Destroy(_enemyController.gameObject);
        }

        public void Follow(Transform target)
        {
            _agent.SetDestination(target.position);
        }


        public void TakeDamage(int value)
        {
            _health -= value;
            if (_health <= 0)
            {
                Die();
            }
        }

        private IEnumerator AttackRoutine(PolygonFPSControler player)
        {
            _isAttacking = true;
            player.player_health -= 30;
            yield return new WaitForSeconds(1f);
            _isAttacking = false;
        }
    }
}

