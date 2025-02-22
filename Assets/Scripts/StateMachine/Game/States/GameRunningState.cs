using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameRunningState : GameState
{
    private PlayerMovement playerInput;

    public GameRunningState(GameStateMachine stateMachine, PlayerMovement input) : base(stateMachine)
    {
        this.playerInput = input;
    }

    public override void Enter()
    {
        playerInput.enabled = true; 
        Time.timeScale = 1f;
    }

    public override void Exit()
    {
        playerInput.enabled = false;
    }

    public override void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            gameStateMachine.ChangeState(new GamePausedState(gameStateMachine, playerInput));
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            gameStateMachine.ChangeState(new GameFinalState(gameStateMachine));
        }
    }
}