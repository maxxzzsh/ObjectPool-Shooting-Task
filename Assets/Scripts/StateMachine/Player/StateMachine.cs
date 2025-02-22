using System.Diagnostics;
using Unity;
using UnityEngine;
using UnityEditor;

public static class StateMachine
{
    private static PlayerState currentState;
    
    public static void ChangeState(PlayerState newState)
    {
        if(currentState!=null && newState.stateType == currentState.stateType)
        {
            Update();
        }
        else
        {
            currentState?.Exit();
            currentState = newState;
            currentState.Enter();
        }
    }
    
    public static void Update()
    {
        currentState?.Update();
    }

    public static PlayerStates GetCurrentState()
    {
        if(currentState != null)
            return(currentState.stateType);
        else
            return(PlayerStates.Shooting);
    }
}

public enum PlayerStates
{
    Shooting,
    RedZone,
    Transparent,
    None
}
