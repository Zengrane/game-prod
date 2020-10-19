
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float movementSpeed;
    public float jumpHeight;

    

    private bool facingRight = true;
    public bool isGrounded = false;

    public PrimaryProjectile projectile;

    private Rigidbody2D rb;
    private Animator anim;
    public ParticleSystem runPart;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>(); //Gets the RigidBody2D from the player
        anim = GetComponent<Animator>(); //Gets the animator component
    }

    private void Update()
    {
        Jump();
 
    }

    void FixedUpdate() //Use for physics
    {
        Vector2 velocity = rb.velocity;
        anim.SetBool("isRunning", false);
        anim.SetBool("isJumping", false);
        anim.SetBool("isShooting", false);

        if (Input.GetKey("a"))
        {

            rb.velocity = new Vector2(-movementSpeed, rb.velocity.y);
            transform.eulerAngles = new Vector3(0, 180, 0);

            if (Input.GetKey("a") && isGrounded)
            {
                anim.SetBool("isRunning", true);
            }


        }

        else if (Input.GetKey("d"))
        {

            rb.velocity = new Vector2(movementSpeed, rb.velocity.y);
            transform.eulerAngles = new Vector3(0, 0, 0); //Changes transform of player rotation. Transform euler angles represents the roational values.


            if (Input.GetKey("d") && isGrounded)
            {
                anim.SetBool("isRunning", true); //Sets the running animation to true.

            }


        }

        else
        {
            rb.velocity = new Vector2(0, rb.velocity.y); //If either keys arent pressed x movement is 0
        }




        if (!isGrounded)
        {
            anim.SetBool("isJumping", true); //Jumping animation is true if the player isnt grounded

        }

        if (Input.GetKey(KeyCode.LeftShift))
        {
            anim.SetBool("isShooting", true); //Shooting animation is true when space is pressed
        }
       


    }   

    void Jump()
    {
        

        if (Input.GetKeyDown("w") && isGrounded == true)
        {
            rb.AddForce(new Vector2(0f, jumpHeight), ForceMode2D.Impulse);
        }
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