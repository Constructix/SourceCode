using System;

namespace StateDesignPattern
{
    public class Context
    {
        private  State _state;

        public State State
        {
            get { return _state; }
            set
            {
                _state = value;
                Console.WriteLine($"State: {_state.GetType().Name}" );
            }
        }

        public void Request()
        {
            _state.Handle(this);
        }


        public Context()
        {
            
        }

        public Context(State state)
        {
            _state = state;
        }
    }
}