using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 2021.9.25
/// </summary>

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float _speed = 2.2f;

    [SerializeField]
    private float _jump = 4.1f;

    [Header("collisions sector")]
    [SerializeField]
    private Transform groundCheckPoint;

    [SerializeField]
    private LayerMask whatIsGround;

    public bool isGrounded;
    private bool canJump;

    Rigidbody2D rb2D;
    // Start is called before the first frame update
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        Jump();
    }

    private void OnTriggerEnter2D(Collider2D c)
    {
        if(c.gameObject.GetComponent<BoostUP>())
        {
            rb2D.velocity = new Vector2(rb2D.velocity.x, 0);
            rb2D.AddForce(transform.up * 6.2f, ForceMode2D.Impulse);
        }
    }

    private void Movement()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(Vector2.right * _speed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(Vector2.right * -_speed * Time.deltaTime);
        }
    }

    private void Jump()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheckPoint.position, .2f, whatIsGround);
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            print("pressed");
            rb2D.velocity = new Vector2(rb2D.velocity.x, 0);
            rb2D.AddForce(transform.up * _jump, ForceMode2D.Impulse);
        }
    }
}
