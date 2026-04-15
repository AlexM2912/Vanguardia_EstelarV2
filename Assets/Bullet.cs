using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 12f;
    public float lifeTime = 2f;

    private Rigidbody2D rb;
    private Vector2 dir = Vector2.right;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void SetDirection(Vector2 direction)
    {
        dir = direction.normalized;
        rb.velocity = dir * speed;
    }

    void Start()
    {
        Destroy(gameObject, lifeTime);
        rb.velocity = dir * speed; // por si no llaman SetDirection
    }
}
