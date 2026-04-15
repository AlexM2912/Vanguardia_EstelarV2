using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed = 3f;
    public float jumpSpeed = 3f;
    private Rigidbody2D rb;
    public bool isGround;
    private Animator animator;
    private bool isFacingRight = false;
    private float horizontal;
    private Transform rotateTransform;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GameObject.FindGameObjectWithTag("Body").GetComponent<Animator>();
        rotateTransform = GameObject.FindGameObjectWithTag("RotatePoint").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        float move = Input.GetAxis("Horizontal");
        float jump = Input.GetAxis("Vertical");
        animator.SetBool("isGround", isGround);
        if (move != 0)
        {
            rb.velocity = new Vector2(move * speed, rb.velocity.y);
            animator.SetBool("movement", true);
        }
        else
        {
            animator.SetBool("movement", false);
        }
        if (jump != 0 && isGround)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpSpeed);
        }
        Flip();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
            isGround = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
            isGround = false;
        }
    }


    public void Flip()
    {
        if (isFacingRight && horizontal > 0f || !isFacingRight && horizontal < 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localscale = transform.localScale;
            localscale.x *= -1;
            transform.localScale = localscale;

            Vector3 scaleRotation = rotateTransform.localScale;
            scaleRotation.x *= -1;
            rotateTransform.localScale = scaleRotation;
        }
    }
}
