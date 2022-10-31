using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DefaultExecutionOrder(-2)]
public class SceneStateMachine : MonoBehaviour
{
    public SceneBaseState CurrentState;

    public void Initialize(SceneBaseState state)
    {
        CurrentState = state;
        CurrentState.Enter();
    }

    public void ChangeState(SceneBaseState newState)
    {
        CurrentState.Exit();
        CurrentState = newState;
        CurrentState.Enter();
    }
}
