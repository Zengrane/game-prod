
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float movementSpeed;
    public float JumpForce;

    private Rigidbody2D rb;

    private bool facingRight;

    private void Start()
    {
        facingRight = true;

        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
       

    }

    private void FixedUpdate()
    {
        var movement = Input.GetAxis("Horizontal");
        transform.position += new Vector3(movement, 0, 0) * Time.deltaTime * movementSpeed; //Changes the position of character on the horizontal axis

        if (Input.GetButtonDown("Jump") && Mathf.Abs(rb.velocity.y) < 0.001f)
        {
            rb.AddForce(new Vector2(0, JumpForce), ForceMode2D.Impulse); //Changes ther position of the character on the vertical axis
        }

        float horizontal = Input.GetAxis("Horizontal");


        Flip(horizontal);
    }

    private void Flip(float horizontal)
    {
        if(horizontal > 0 && !facingRight || horizontal < 0 && facingRight)
        {
            facingRight = !facingRight;

            Vector3 theScale = transform.localScale;

            theScale.x *= -1;

            transform.localScale = theScale;
        }
    }



}