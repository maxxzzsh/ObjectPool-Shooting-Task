public abstract class GameState
{
    protected GameStateMachine gameStateMachine;

    public GameState(GameStateMachine stateMachine)
    {
        this.gameStateMachine = stateMachine;
    }

    public abstract void Enter();
    public abstract void Exit();
    public abstract void Update();
}