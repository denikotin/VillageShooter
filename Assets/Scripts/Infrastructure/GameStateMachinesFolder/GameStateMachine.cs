using System;
using System.Collections.Generic;
using Assets.Scripts.Infrastructure.Services;
using Assets.Scripts.Infrastructure.GameStateMachinesFolder.States;

namespace Assets.Scripts.Infrastructure.GameStateMachinesFolder
{
    public class GameStateMachine : IService
    {
        private Dictionary<Type, IState> _states = new Dictionary<Type, IState>();
        private IState _currentState;

        public GameStateMachine(SceneLoader sceneLoader, ServiceLocator serviceLocator)
        {
            CreateStates(sceneLoader, serviceLocator) ;
        }

        private void CreateStates(SceneLoader sceneLoader, ServiceLocator serviceLocator)
        {
            _states[typeof(BootstrapState)] = new BootstrapState(this, serviceLocator, sceneLoader);
            _states[typeof(LoadProgressState)] = new LoadProgressState(this, serviceLocator);
            _states[typeof(LoadMainMenuState)] = new LoadMainMenuState(this, serviceLocator, sceneLoader);
            _states[typeof(LoadPlaySceneState)] = new LoadPlaySceneState(this, serviceLocator, sceneLoader);


        }

        public void EnterState<TState>() where TState: IState
        {
            if (_currentState != null)
            {
                _currentState.Exit();
            }

            IState state = GetState<TState>();
            state.Enter();
            _currentState = state;
        }

        public void EnterState<TState>(int level) where TState : IPayloadState
        {
            if (_currentState != null)
            {
                _currentState.Exit();
            }

            IPayloadState state = GetState<TState>();
            state.Enter(level);
            _currentState = state;
        }

        private TState GetState<TState>() where TState: IState
        {
            return (TState)_states[typeof(TState)]; 
        }

    }
}
