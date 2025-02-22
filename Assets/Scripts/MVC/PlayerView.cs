using UnityEngine;
using UnityEngine.UI;

public class PlayerView : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    private Text healthText;
    private PlayerController controller;
    
    public void Initialize(PlayerController playerController, Text text, int startValue)
    {
        controller = playerController;
        healthText = text;
        UpdateHealth(startValue);
    }
    
    public void UpdateHealth(int health)
    {
        healthText.text = "HP: " + health;
    }
    
    public void OnDeath()
    {
        spriteRenderer.color = Color.red;
    }
}
