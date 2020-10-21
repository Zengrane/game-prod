using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed;

    private Rigidbody2D rb;

    private Animation anim;

    public Transform enemyProjectile;
    public ParticleSystem explosion;

    public float lifeTime;

    private void Awake()
    {
        Destroy(gameObject, lifeTime);
    }

    // Start is called before the first frame update
    void Start()
    {
        

        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animation>();


    }

        
    

    // Update is called once per frame
    void Update()
    {
        rb.velocity = transform.right * speed;
        anim.Play();

        
        

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        var enemy = collision.collider.GetComponent<EnemyBehaviour>(); //Gets the enemy behaviour script 
        if (enemy)
        {
            enemy.TakeHit(1); //If the collision is the phantom enemy, do one damage
        }


        Destroy(gameObject);
        Instantiate(explosion, transform.position, transform.rotation); //Activates the explosion particle effect after destroying the game object
    }
}
