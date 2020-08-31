using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grounded : MonoBehaviour
{
 
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
      
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
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
