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

    public ParticleSystem trail;

    public Transform projectile;

    // Start is called before the first frame update
    void Start()
    {
       

        bulletRB = GetComponent<Rigidbody2D>();
        target = GameObject.FindGameObjectWithTag("Player");
        Vector2 moveDir = (target.transform.position - transform.position).normalized * speed;
        bulletRB.velocity = new Vector2(moveDir.x, moveDir.y);

    }

    private void Update()
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

    }




}
