using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameFinalState : GameState
{
    public GameFinalState(GameStateMachine stateMachine) : base(stateMachine) { }

    public override void Enter()
    {
        PlayerController player = GameObject.FindObjectOfType<PlayerController>();
        player.GetComponent<PlayerMovement>().enabled = false;

        SpriteRenderer sprite = player.GetComponent<PlayerCombat>().playerSprite;
        sprite.color = Color.green;
        Color color = sprite.color;
        color.a = 1f;
        sprite.color = color;

        player.GetComponent<PlayerCombat>().redZone.SetActive(false);
    }

    public override void Exit() { }

    public override void Update() { }
}