using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    public float jumpForce;
    public bool grounded;
    private bool jumping;
    private float jumpTimeCounter;
    public float jumpTime;
    private bool isJumping;
    public ParticleSystem dust;
    public LayerMask whatIsGround;


    public Transform groundCheck;
    
    
    private Rigidbody2D rb2d;
    public Animator anim;



    void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        grounded = Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground"));
       
            
        if(GetComponent<Player>().isAlive)
        {
            if (Input.GetKeyDown(KeyCode.Space) && grounded || Input.GetKeyDown(KeyCode.UpArrow) && grounded)
            {
                CreateDust();
                isJumping = true;
                jumpTimeCounter = jumpTime;
                rb2d.velocity = Vector2.up * jumpForce;
            }
            anim.SetBool("JumpFall", rb2d.velocity.y != 0);

            if (Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.UpArrow) && isJumping)
            {
                if(jumpTimeCounter > 0)
                {
                    rb2d.velocity = Vector2.up * jumpForce;
                    jumpTimeCounter -= Time.deltaTime;
                } else
                {
                    isJumping = false;
                }
            }

            if(Input.GetKeyUp(KeyCode.Space) || Input.GetKeyUp(KeyCode.UpArrow))
            {
                isJumping = false;
            }
        }
            
    }

    void CreateDust() 
    {
        dust.Play();
    }
}
