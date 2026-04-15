using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Disparo")]
    public GameObject bulletPrefab;
    public Transform firePoint;

    [Header("Movimiento")]
    public float speed = 6f;

    [Header("Salto")]
    public float jumpForce = 8f;

    [Header("Detección de suelo")]
    public Transform groundCheck;
    public float groundCheckRadius = 0.25f;
    public LayerMask groundLayer;

    [Header("Anti doble-salto fantasma")]
    public float groundLockTime = 0.08f;

    private Rigidbody2D rb;
    private float moveInput;
    private bool jumpPressed;
    private float groundLockTimer;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        groundLockTimer = 0f;
    }

    void Update()
    {
        // Input
        moveInput = Input.GetAxisRaw("Horizontal");
        jumpPressed = Input.GetButtonDown("Jump") || Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W);

        // Disparo
        if (Input.GetMouseButtonDown(0))
            Shoot();

        // Timer
        groundLockTimer -= Time.deltaTime;
    }

    void FixedUpdate()
    {
        // 1) Movimiento SIN romper el salto (no pongas Y=0)
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);

        // 2) Detectar suelo por LayerMask
        bool overlapGround =
            groundCheck != null &&
            Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

        bool isGrounded = overlapGround && groundLockTimer <= 0f;

        // 3) Salto
        if (jumpPressed && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            groundLockTimer = groundLockTime; // evita doble salto fantasma
        }
    }

    void Shoot()
    {
        if (bulletPrefab == null || firePoint == null) return;

        GameObject b = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);

        Bullet bullet = b.GetComponent<Bullet>();
        if (bullet != null)
        {
            // Por ahora dispara a la derecha. Luego lo hacemos hacia el mouse.
            bullet.SetDirection(Vector2.right);
        }
    }

    void OnDrawGizmosSelected()
    {
        if (groundCheck == null) return;
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
    }
}
