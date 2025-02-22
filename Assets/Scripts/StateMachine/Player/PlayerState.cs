using System.Data;

public abstract class PlayerState
{
    protected PlayerController player;
    public abstract PlayerStates stateType {get;set;}
    public PlayerState(PlayerController player) { this.player = player; }
    public abstract void Enter();
    public abstract void Exit();
    public abstract void Update();
}