using UnityEngine;

public class EnemyCollision : MonoBehaviour
{
    public int damage = 10;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerView playerView = collision.GetComponent<PlayerView>();
        if (playerView != null)
        {
            PlayerController playerController = playerView.GetComponent<PlayerController>();
            playerController?.TakeDamage(damage);
        }
    }
}