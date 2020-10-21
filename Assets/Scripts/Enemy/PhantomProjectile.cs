using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PhantomProjectile : MonoBehaviour
{
    GameObject target;
    public float speed;
    Rigidbody2D bulletRB;

    private float turnSpeed = 5f;

    public ParticleSystem trail;

    public Transform projectile;

    public ParticleSystem explosion;


    // Start is called before the first frame update
    void Start()
    {
       

        bulletRB = GetComponent<Rigidbody2D>();
        target = GameObject.FindGameObjectWithTag("Player");

        //Vector2 moveDir = (target.transform.position - transform.position).normalized * speed;
        
        //bulletRB.velocity = new Vector2(moveDir.x, moveDir.y);

     

    }

    private void Update()
    {

        MoveTowards(target.transform.position);
        RotateTowards(target.transform.position);
        

    }

    private void MoveTowards(Vector2 target)
    {
        transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);
    }

    private void RotateTowards(Vector2 target)
    {
        var offset = 270f;
        Vector2 direction = target - (Vector2)transform.position;
        direction.Normalize();
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(Vector3.forward * (angle + offset));
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
