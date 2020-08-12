
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float movementSpeed = 10;

    public Vector2 direction;

    private Rigidbody2D rb;

    private bool facingRight = true;

    public Transform feet;
    public Vector3 velocity;
    public float gravityMultiplier;

    private void Start()
    {
        
    }

    private void Update()
    {
        bool grounded = Physics2D.Raycast(feet.transform.position, Vector3.down, 0.1f);

        direction = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")); //Gets the horizontal and vertical axis

        if (!grounded)
        
            velocity += Physics.gravity * gravityMultiplier * Time.deltaTime;
        



        else if (velocity.y < 0)
        
            velocity = Vector3.zero;

            transform.position += velocity * Time.deltaTime;
        
        
        
            


    }

    void moveCharacter(float horizontal)
    { 

        if((horizontal > 0 && !facingRight) || (horizontal < 0 && facingRight)) //If input is in opposite direction, object will be flipped
        {
            Flip();
        }
    }

    void FixedUpdate() //Use for physics
    {
        moveCharacter(direction.x); 
    }
    
    void Flip()
    {
        facingRight = !facingRight;
        transform.rotation = Quaternion.Euler(0, facingRight ? 0 : 180 , 0) ; //Flips the object to face left or right
    }
    

  



}