using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    Rigidbody2D rb;
    CircleCollider2D circleCollider;

    [SerializeField] float jumpingPower;
    [SerializeField] float speed;
    [SerializeField] Transform groundcheck;
    [SerializeField] LayerMask groundlayer;

    private float vertical;
    private float horizontal;

    Health health;

    void Awake()
    {
        health = FindObjectOfType<Health>();
    }

    void Start()
    {     
        circleCollider = GetComponent<CircleCollider2D>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
    }

    public void Move(InputAction.CallbackContext context)
    {
        horizontal = context.ReadValue<Vector2>().x;
    }

    public void Jump(InputAction.CallbackContext context)
    {
        if(context.performed &&  IsGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
        }

        if(context.canceled && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
        }

        if (!circleCollider.IsTouchingLayers(LayerMask.GetMask("Platforms")))
        {
            return;
        }
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundcheck.position, 0.2f, groundlayer);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            health.TakeDamage(20);
            rb.velocity = new Vector2(0, 7);
        }
        if(collision.gameObject.tag == "deathArea")
        {
            health.Die();
        }
    }
}
    
