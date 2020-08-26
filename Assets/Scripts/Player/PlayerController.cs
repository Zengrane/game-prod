
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

       

        Vector2 velocity = rb.velocity; 
        anim.SetBool("isRunning", false);
        anim.SetBool("isJumping", false);

        if (velocity.y < 0)
        {
            anim.SetBool("isJumping", true);
            anim.SetBool("isRunning", false);
        }

        velocity.x = 0;

        if (Input.GetKey("a"))
        {   
            velocity.x -= movementSpeed;

            if(Input.GetKey("a") && isGrounded)
            {
                anim.SetBool("isRunning", true);
            }
            
        }

        if (Input.GetKey("d"))
        {
            velocity.x += movementSpeed;
            anim.SetBool("isRunning", true);
        }

        rb.velocity = velocity;


        if (velocity.x < 0) //If the move input is less than zero, the player changes their direction to the left
         {
            transform.eulerAngles = new Vector3(0, 180, 0);
            
        }

        else if (velocity.x > 0)  //If the move input is more than zero, the player changes their direction to the right
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }

       
    }

    void FixedUpdate() //Use for physics
    {
        

    }   

    void Jump()
    {
        

        if (Input.GetButtonDown("Jump") && isGrounded == true)
        {
            rb.AddForce(new Vector2(0f, jumpHeight), ForceMode2D.Impulse);
        }
    }
     

       
      
    




  



}