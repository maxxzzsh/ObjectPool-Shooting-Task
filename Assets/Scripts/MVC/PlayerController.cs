using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public PlayerCombat combat;
    public BulletPool bulletPool;
    private PlayerModel model;
    private PlayerView view;
    private bool isMovable = true;

    public void Initialize(PlayerModel playerModel, PlayerView playerView, PlayerCombat combat)
    {
        model = playerModel;
        view = playerView;
        this.combat = combat;
        
        model.OnHealthChange += view.UpdateHealth;
        model.OnPlayerDeath += () => {isMovable = false;};
        model.OnPlayerDeath += view.OnDeath;
    }
    
    public void TakeDamage(int damage)
    {
        model.ChangeHealth(-damage);
    }

    public void Move(Vector2 direction, float speed)
    {
        if(isMovable)
            transform.position += (Vector3)direction * speed * Time.deltaTime;
    }

    public void SetAttackState()
    {
        StateMachine.ChangeState(new ShootingState(this));
    }

    public void SetRZState()
    {
        StateMachine.ChangeState(new RedZoneState(this));
    }

    public void SetTPState()
    {
        StateMachine.ChangeState(new TransparencyState(this));
    }

    public void SetNextState()
    {
        switch (StateMachine.GetCurrentState())
        {
            case PlayerStates.Shooting: StateMachine.ChangeState(new RedZoneState(this)); break;
            case PlayerStates.RedZone: StateMachine.ChangeState(new TransparencyState(this)); break;
            case PlayerStates.Transparent: StateMachine.ChangeState(new ShootingState(this)); break;
        }
        
    }
}