using Assets.Scripts.Data.Enums;
using Assets.Scripts.Infrastructure.EntryPoint;
using System;
using UnityEngine;
using UnityEngine.AI;

namespace Assets.Scripts.Logic.Enemies.AdventurerFolder
{
    public class EnemyController : MonoBehaviour, ICoroutineRunner
    {
        [SerializeField] EnemyID _enemyID;

        private AnimationController _animController;
        private EnemyState _currentState;
        private Transform _player;
        private PolygonFPSControler _polygonFPSControler;
        private IEnemy _enemy;
        private NavMeshAgent _agent;

        public void Construct(Transform player)
        {
            _player = player;
        }

        public void Initialize()
        {
            _agent = GetComponent<NavMeshAgent>();
            _animController = GetComponent<AnimationController>();
            _currentState = EnemyState.Idle;
            CreateEnemy();
        }

        public void Start()
        {
            _player = FindAnyObjectByType<PolygonFPSControler>().transform;
            _polygonFPSControler = _player.GetComponent<PolygonFPSControler>();
            Initialize();
        }

        public void Update()
        {
            ChangeState();
            switch (_currentState)
            {
                case EnemyState.Idle:
                    ExecuteIdleState();
                    break;
                case EnemyState.Move:
                    ExecuteMoveState();
                    break;
                case EnemyState.Attack:
                    ExecuteAttackState();
                    break;
            }
        }

        public EnemyID GetEnemyType() => _enemyID;

        public void SubscribeOnEnemyDeath(Action<IEnemy> action) => _enemy.OnEnemyDeath += action;
        public void UnSubscribeOnEnemyDeath(Action<IEnemy> action) => _enemy.OnEnemyDeath -= action;

        public void TakeDamage(int value, bool isHeadshot)
        {
            if (isHeadshot)
            {
                _enemy.Die();
            }
            else
            {
                _enemy.TakeDamage(value);
            }
        }

        private void ChangeState()
        {
            if (DoesTargetNear())
            {
                _currentState = EnemyState.Attack;
                //Debug.Log($"{gameObject.name} in Attack state");
                return;
            }

            _currentState = EnemyState.Move;
            //Debug.Log($"{gameObject.name} in Move state");
        }

        private void ExecuteIdleState()
        {
            _animController.DisableRunAnimation();

        }

        private void ExecuteMoveState()
        {
            FollowPlayer();
        }

        private void ExecuteAttackState()
        {
            AttackPlayer();
        }


        private void FollowPlayer()
        {
            _enemy.Follow(_player);
            _animController.EnableRunAnimation();
        }

        private void AttackPlayer()
        {
            _animController.DisableRunAnimation();
            _enemy.Attack(_polygonFPSControler);
            _animController.EnablePunchAnimation();
        }

        private void CreateEnemy()
        {
            switch(_enemyID)
            {
                case EnemyID.Toilet:
                    ConstructToilet();
                    break;
                case EnemyID.BossToilet:
                    ConstructBoss();
                    break;               
            }
        }

        private void ConstructToilet()
        {
            _enemy = new Toilet(this);
            if (_agent != null)
            {
                _enemy.Initialize(_agent, this, _animController);
            }
        }

        private void ConstructBoss()
        {
            _enemy = new BossToilet(this);
            if (_agent != null)
            {
                _enemy.Initialize(_agent, this, _animController);
            }
        }

        private bool DoesTargetNear() 
        {
            if(_enemy is BossToilet)
            {
                if (Vector3.Distance(_agent.transform.position, _player.position) < 6f)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

            if (Vector3.Distance(_agent.transform.position, _player.position) < 3f)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
