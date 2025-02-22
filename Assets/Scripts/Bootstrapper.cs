using UnityEngine;
using UnityEngine.UI;

public class Bootstrapper : MonoBehaviour
{
    public GameObject playerPrefab;
    public Transform spawnPoint;
    public int playerHealth = 100;
    public Text healthText;
    private GameStateMachine gameStateMachine;
    
    private void Start()
    {
        GameObject playerInstance = Instantiate(playerPrefab, spawnPoint.position, Quaternion.identity);
        PlayerView playerView = playerInstance.GetComponent<PlayerView>();
        PlayerController playerController = playerInstance.GetComponent<PlayerController>();
        PlayerMovement playerMovement = playerInstance.GetComponent<PlayerMovement>();
        PlayerCombat combat = playerInstance.GetComponent<PlayerCombat>();
        
        PlayerModel playerModel = new PlayerModel(playerHealth);
        playerController.Initialize(playerModel, playerView, combat);
        playerView.Initialize(playerController, healthText, playerHealth);
        playerMovement.Initialize(playerController);
        
        gameStateMachine = new GameStateMachine();
        gameStateMachine.ChangeState(new GameRunningState(gameStateMachine, playerMovement));
    }

    private void Update()
    {
        gameStateMachine.Update();
    }
}
