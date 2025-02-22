using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePausedState : GameState
{
    private PlayerMovement playerInput;

    public GamePausedState(GameStateMachine stateMachine, PlayerMovement input) : base(stateMachine)
    {
        this.playerInput = input;
    }

    public override void Enter()
    {
        playerInput.enabled = false;
        Time.timeScale = 0f;
    }

    public override void Exit()
    {
        playerInput.enabled = true;
        Time.timeScale = 1f;
    }

    public override void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            gameStateMachine.ChangeState(new GameRunningState(gameStateMachine, playerInput));
        }
    }
}
