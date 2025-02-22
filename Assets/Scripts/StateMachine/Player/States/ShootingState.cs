using UnityEngine;

public class ShootingState : PlayerState
{
    public ShootingState(PlayerController player) : base(player) {}
    public override PlayerStates stateType {get {return(_stateType);} set {}}
    public BulletPool bulletPool;
    private PlayerStates _stateType = PlayerStates.Shooting;
    public override void Enter()
    {
        bulletPool = player.bulletPool;
        //GameObject bullet = GameObject.Instantiate(player.combat.bulletPrefab, player.combat.firePoint.position, Quaternion.identity);
        //bullet.GetComponent<Rigidbody2D>().velocity = Vector2.down * 2f;
        Bullet bullet = bulletPool.GetBullet();
        if (bullet != null)
        {
            bullet.transform.position = player.gameObject.transform.position;
            //bullet.transform.rotation = firePoint.rotation;
            bullet.Fire(-player.gameObject.transform.up);
        }
    }
    public override void Exit() {}
    public override void Update() 
    {
        //GameObject bullet = GameObject.Instantiate(player.combat.bulletPrefab, player.combat.firePoint.position, Quaternion.identity);
        //bullet.GetComponent<Rigidbody2D>().velocity = Vector2.down * 2f;
        _stateType = PlayerStates.None;
        
    }
}