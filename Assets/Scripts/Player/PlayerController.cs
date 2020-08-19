
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float movementSpeed;

    public float jumpHeight;

    public Vector2 direction;

    private Rigidbody2D rb;

    private bool facingRight = true;

    public Transform feet;
   
    public Vector3 velocity;
    public float gravityMultiplier;


    private Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>(); //Gets the animator component
    }

    private void Update()
    {
       
    }

    void FixedUpdate() //Use for physics
    {
       


        bool grounded = Physics2D.Raycast(feet.transform.position, Vector3.down, 0.1f);

        direction = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")); //Gets the horizontal and vertical axis

        if (!grounded) //If the object is not touching the ground, gravity is applied to the object



            velocity += Physics.gravity * gravityMultiplier * Time.deltaTime;



        else if (velocity.y < 0) //If the object is touching the ground, remove gravity


            velocity = Vector3.zero;

        transform.position += velocity * Time.deltaTime;


        if (Input.GetKey("space") && grounded) //If the space key is pressed and the object is touching the ground, allow it to jump
        {   

            velocity.y = jumpHeight;
        }

       if (grounded)
        {
            anim.SetBool("isJumping", false);
        }

       else if (!grounded)
        {
            anim.SetBool("isRunning", false);
            anim.SetBool("isJumping", true);


        }



       if (Input.GetKey("d") && Input.GetKey("a"))
        {
            velocity.x = 0;
            anim.SetBool("isRunning", false);
        }



        else if (Input.GetKey("d")) //Gets the input of key d to move the object and sets it's velocity to it's movement speed
        {
            velocity.x = movementSpeed;

            if (Input.GetKey("d") && grounded)
            {
                anim.SetBool("isRunning", true);
            }

            else
            {
                anim.SetBool("isRunning", false);
            }

        }


       

        else if (Input.GetKey("a"))  //Gets the input of key a to move the object and sets it's velocity to it's -movement speed

        {
            velocity.x = -movementSpeed;

            if (Input.GetKey("a") && grounded)
            {
                anim.SetBool("isRunning", true);
            }

            else
            {
                anim.SetBool("isRunning", false);
            }
        }




        else //If no other keys are pressed, velocity is zero and the object wont move
        {
           
            velocity.x = 0f;
            anim.SetBool("isRunning", false);
         
        }

        float moveInput = Input.GetAxisRaw("Horizontal");






        if (moveInput < 0) //If the move input is less than zero, the player changes their direction to the left
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }

        else if (moveInput > 0)  //If the move input is more than zero, the player changes their direction to the right
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }

      
    }




  



}