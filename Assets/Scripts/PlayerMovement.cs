using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;
    public bool AttackPressed { get; private set; }
    public bool ToggleZonePressed { get; private set; }
    public bool ToggleTransparencyPressed { get; private set; }
    public bool EnterPressed { get; private set; }
    public KeyCode shootingCode = KeyCode.F;
    public KeyCode redZoneCode = KeyCode.G;
    public KeyCode transparencyCode = KeyCode.H;
    private PlayerController controller;
    
    public void Initialize(PlayerController playerController)
    {
        controller = playerController;
    }
    
    void Update()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");
        AttackPressed = Input.GetKeyDown(shootingCode);
        ToggleZonePressed = Input.GetKeyDown(redZoneCode);
        ToggleTransparencyPressed = Input.GetKeyDown(transparencyCode);
        EnterPressed = Input.GetKeyDown(KeyCode.Return);
        
        controller?.Move(new Vector2(moveX, moveY), speed);
        if(AttackPressed)
        {
            controller?.SetAttackState();
        }
        if(ToggleZonePressed)
        {
            controller?.SetRZState();
        }
        if(ToggleTransparencyPressed)
        {
            controller?.SetTPState();
        }
        if(EnterPressed)
        {
            controller?.SetNextState();
        }
    }
}