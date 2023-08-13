﻿using System;
using System.Collections.Generic;

namespace Toolbox
{
	/// <summary>
	/// Represents a basic state machine that holds and manages states of type T. 
	/// Allows for state changes and invokes an event whenever a state change occurs. 
	/// Provides properties for accessing the current and previous states.
	/// </summary>
    public class StateMachine<T>
	{
		public T CurrentState { get; private set; }
		public T PreviousState { get; private set; }

		public event Action OnStateChange;

        public StateMachine(T initialState)
        {
            CurrentState = initialState;
            PreviousState = initialState;
        }

        public void ChangeState(T newState)
		{
			if (EqualityComparer<T>.Default.Equals(newState, CurrentState))
			{
				return;
			}

			PreviousState = CurrentState;
			CurrentState = newState;
			OnStateChange?.Invoke();
		}
	}
}
