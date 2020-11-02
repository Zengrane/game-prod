
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LuciusProjectile : MonoBehaviour
{
    public GameObject target;
    public float speed;
    Rigidbody2D bulletRB;

    public float turnSpeed = 200f;

    public Transform projectile;

    public ParticleSystem explosion;

    public float lifeTime;

    private void Awake()
    {
        Destroy(gameObject, lifeTime);

        
        
        
    }


    // Start is called before the first frame update
    void Start()
    {

        bulletRB = GetComponent<Rigidbody2D>();

        target = GameObject.FindGameObjectWithTag("Player");

        //Vector2 moveDir = (target.transform.position - transform.position).normalized * speed;

        //bulletRB.velocity = new Vector2(moveDir.x, moveDir.y);



    }

    private void FixedUpdate()
    {
        Vector2 point2Target = (Vector2)transform.position - (Vector2)target.transform.position;

        point2Target.Normalize();

        float value = Vector3.Cross(point2Target, transform.up).z;

        if(value > 0)
        {
            bulletRB.angularVelocity = turnSpeed;
        }

        else if(value < 0)
        {
            bulletRB.angularVelocity = -turnSpeed;
        }

        else
        {
            turnSpeed = 0;

        }

        bulletRB.velocity = transform.up * speed;


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

    private void DoInstantiate()
    {
        
       
    }


}