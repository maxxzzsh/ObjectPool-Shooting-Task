public class GameStateMachine
{
    private GameState currentState;

    public void ChangeState(GameState newState)
    {
        currentState?.Exit();
        currentState = newState;
        currentState.Enter();
    }

    public void Update()
    {
        currentState?.Update();
    }
}