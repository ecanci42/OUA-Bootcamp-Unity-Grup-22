using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    bool grounded=true;
    bool moving;
    bool jump;
    public float speed = 3.0f;
    public float jumpForce = 15.0f;
    float moveDirection;
    Animator animator;
    Rigidbody2D rb2D;
    SpriteRenderer spriteRenderer;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    // Start is called before the first frame update
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void FixedUpdate()
    {
        if (rb2D.velocity != Vector2.zero)
        {
            moving = true;
        }
        else
        {
            moving = false;
        }
         
        rb2D.velocity = new Vector2(speed* moveDirection, rb2D.velocity.y);

        if (jump==true)
        {
            rb2D.velocity = new Vector2(rb2D.velocity.x,jumpForce);
            jump = false;
           
        }

    }
    // Update is called once per frame
    void Update()
    {
        if (grounded==true&&Input.GetKey(KeyCode.A)||Input.GetKey(KeyCode.D))
        {
            
            if (Input.GetKey(KeyCode.A))
            {
                moveDirection = -1.0f;
                spriteRenderer.flipX = true;
                animator.SetFloat("speed", speed);

            } else if (Input.GetKey(KeyCode.D))
             {
                moveDirection = 1.0f;
                spriteRenderer.flipX = false;
                animator.SetFloat("speed", speed);
             }
           
        } else if (grounded==true)
         {
            moveDirection = 0.0f;
            animator.SetFloat("speed", 0.0f);
         }
       

        if (grounded == true && Input.GetKey(KeyCode.Space))
        {
            jump = true;
            grounded = false;
            animator.SetTrigger("jump");
            animator.SetBool("grounded", grounded);


        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {

        }
        grounded = true;
        animator.SetBool("grounded", grounded);
    }
}
