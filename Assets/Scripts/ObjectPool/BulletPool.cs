using UnityEngine;

public class BulletPool : MonoBehaviour
{
    public Bullet bulletPrefab;
    public int startPoolSize = 5;
    public int maxPoolSize = 20;

    private ObjectPool<Bullet> pool;

    private void Awake()
    {
        pool = new ObjectPool<Bullet>(bulletPrefab, startPoolSize, maxPoolSize, transform);
    }

    public Bullet GetBullet()
    {
        Bullet bullet = pool.TryGetFromPool();
        if (bullet != null)
        {
            bullet.Initialize(pool);
        }
        return bullet;
    }
}