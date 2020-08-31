
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float movementSpeed;
    public float jumpHeight;

    

    private bool facingRight = true;
    public bool isGrounded = false;

    private Rigidbody2D rb;
    private Animator anim;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>(); //Gets the RigidBody2D from the player
        anim = GetComponent<Animator>(); //Gets the animator component
    }

    private void Update()
    {
        Jump();
        Shoot(); 

        Vector2 velocity = rb.velocity;
        anim.SetBool("isRunning", false);
        anim.SetBool("isJumping", false);
        anim.SetBool("isShooting", false);
        
        if (Input.GetKey("a"))
        {
            rb.velocity = new Vector2(-movementSpeed, rb.velocity.y);

            if (Input.GetKey("a") && isGrounded)
            {
                anim.SetBool("isRunning", true);
            }

        }

        else if (Input.GetKey("d"))
        {
            rb.velocity = new Vector2(movementSpeed, rb.velocity.y);

            if (Input.GetKey("d") && isGrounded)
            {
                anim.SetBool("isRunning", true);
            }

            else if(Input.GetKey("d") && (Input.GetKeyDown("space")))
            {
                anim.SetBool("isShooting", true);
            }
        }

        if (velocity.x < 0) //If the move input is less than zero, the player changes their direction to the left
        {
            transform.eulerAngles = new Vector3(0, 180, 0);

        }

        else if (velocity.x > 0)  //If the move input is more than zero, the player changes their direction to the right
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }

        if (velocity.y > 0)
        {
            anim.SetBool("isRunning", false);
        }

        if (!isGrounded)
        {
            anim.SetBool("isJumping", true);
            
        }


        if (Input.GetKeyDown("space"))
        {
            anim.SetBool("isShooting", true);
        }



    }

    void FixedUpdate() //Use for physics
    {
        

    }   

    void Jump()
    {
        

        if (Input.GetKeyDown("w") && isGrounded == true)
        {
            rb.AddForce(new Vector2(0f, jumpHeight), ForceMode2D.Impulse);
        }
    }

    void Shoot()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Ground")
        {
            //if(transform.position.y > collision.contacts[0].point.y) // TODO???
            {
                GetComponent<PlayerController>().isGrounded = true; //Changes the isGrounded bool in the player controller script to true if collided with the ground


            }

        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.tag == "Ground")
        {
            GetComponent<PlayerController>().isGrounded = false; //Changes the isGrounded bool in the player controller script to false if not collided with the ground
        }
    }














}