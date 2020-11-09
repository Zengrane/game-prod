using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PhantomProjectile : MonoBehaviour
{
    public GameObject target;
    public float speed;
    Rigidbody2D bulletRB;

    private float turnSpeed = 200f;

    public ParticleSystem trail;

    public Transform projectile;

    public ParticleSystem explosion;


    // Start is called before the first frame update
    void Start()
    {
       

        bulletRB = GetComponent<Rigidbody2D>();

        target = GameObject.FindGameObjectWithTag("Player");

        Vector2 moveDir = (target.transform.position - transform.position).normalized * speed;
        
       bulletRB.velocity = new Vector2(moveDir.x, moveDir.y);

     

    }

    private void FixedUpdate()
    {
        

    }

   

    private void OnCollisionEnter2D(Collision2D collision)
    {
        var playerCollider = collision.collider.GetComponent<Health>(); //Gets the enemy behaviour script 


        if (playerCollider)
        {
            playerCollider.TakeHit(1); //If the collision is the phantom enemy, do one damage
        }


        Destroy(gameObject);
        Instantiate(explosion, transform.position, transform.rotation); //Activates the explosion particle effect after destroying the game object
    }




}
