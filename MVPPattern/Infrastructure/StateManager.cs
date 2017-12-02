using System;
using System.Collections.Generic;

namespace MVPPattern.Infrastructure
{
    public sealed class StateManager
    {
        private static readonly Lazy<StateManager> lazy = new Lazy<StateManager>(() => new StateManager());

        public static StateManager Instance { get { return lazy.Value; } }

        private StateManager()
        {
            _states = new Dictionary<Type, object>();
        }

        private readonly Dictionary<Type, object> _states;

        public object GetState(Type type)
        {
            if (_states.ContainsKey(type))
            {
                return _states[type];
            }
            return null;
        }

        public void SetState(Type type, object newState)
        {
            _states[type] = newState;
        }
    }
}