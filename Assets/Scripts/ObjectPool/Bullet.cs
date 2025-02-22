using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speed = 10f;
    public float startLifeTime = 3f;
    private float lifeTime;

    private ObjectPool<Bullet> pool;

    public void Initialize(ObjectPool<Bullet> pool)
    {
        lifeTime = startLifeTime;
        this.pool = pool;
        rb = GetComponent<Rigidbody2D>();
    }

    public void Fire(Vector2 direction)
    {
        lifeTime = startLifeTime;
        rb.velocity = direction * speed;
        Invoke(nameof(ReturnToPool), lifeTime);
    }

    private void ReturnToPool()
    {
        lifeTime = startLifeTime;
        pool.ReturnToPool(this);
    }
}