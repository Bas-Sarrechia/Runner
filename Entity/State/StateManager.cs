using System;
using System.Collections.Generic;
using Godot;

public class StateManager
{
    private readonly State[] _states;

    private State _currentState;

    private StateManager(State startState, params State[] states)
    {
        _currentState = startState;
        _states = states;
    }

    private void TransitionState(string transitionTo)
    {
        if (transitionTo == _currentState.GetStateName()) return;
        var transitionState = Array.Find(_states, state => state.GetStateName() == transitionTo);
        if (transitionState == null) return;
        _currentState.Exit();
        _currentState = transitionState;
        _currentState.Enter();
    }

    public void PhysicsProcess(float delta)
    {
        TransitionState(_currentState.PhysicsProcess(delta));
    }

    public void Input(InputEvent @event)
    {
        TransitionState(_currentState.ProcessInput(@event));
    }

    public class StateManagerBuilder : StateManagerInitializer, StateManagerBuilderStateModifier
    {
        private State _initialState;
        private readonly List<State> _states = new List<State>();

        private StateManagerBuilder()
        {
        }

        public static StateManagerInitializer Instance()
        {
            return new StateManagerBuilder();
        }

        public StateManagerBuilderStateModifier SetDefaultState(State defaultState)
        {
            _initialState = defaultState;
            _states.Add(defaultState);
            return this;
        }

        public StateManagerBuilderStateModifier AddState(State state)
        {
            _states.Add(state);
            return this;
        }

        public StateManager Build()
        {
            return new StateManager(_initialState, _states.ToArray());
        }
    }
}