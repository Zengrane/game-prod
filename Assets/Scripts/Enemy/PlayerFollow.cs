using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFollow : MonoBehaviour
{
    public float speed;
    public float stoppingDistance;
    public float shootingRange;
    public float fireRate = 5f;
    private float nextFireTime;
    public GameObject enemyProj;
    public GameObject enemyProjParent;
    public float lineOfSite;
    public SpriteRenderer spriteRend;

    private Rigidbody2D rb2d;

    private Transform target; //player enemy is chasing



    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame

    void Update()
    {


        float distanceFromPLayer = Vector2.Distance(target.position, transform.position);
        if(distanceFromPLayer < lineOfSite)
        {
            if (transform.position.x < target.position.x) //If the enemy position is less than x, the enemy moves right
            {
                rb2d.velocity = new Vector2(speed, 0);
                spriteRend.flipX = true;
                enemyProjParent.transform.localPosition = new Vector2(0.389f, enemyProjParent.transform.localPosition.y);
            }

            else if (transform.position.x > target.position.x) //If the enemy position is greater than x, the enemy moves right
            {
                rb2d.velocity = new Vector2(-speed, 0);
                spriteRend.flipX = false;
                enemyProjParent.transform.localPosition = new Vector2(-0.389f, enemyProjParent.transform.localPosition.y);

           
            }

       
        }

      

        if (distanceFromPLayer <= shootingRange && nextFireTime < Time.time)
        {
            Shoot(target.position); 

            nextFireTime = Time.time + fireRate;

            
        }

        if (distanceFromPLayer < stoppingDistance)
        {
            rb2d.velocity = new Vector2(0, 0);
        }
    }

    public virtual void Shoot(Vector3 target)
    {
        GameObject proj = Instantiate(enemyProj, enemyProjParent.transform.position, Quaternion.identity);


        proj.transform.up = target - transform.position;
    }



    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, lineOfSite);

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, shootingRange);

        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, stoppingDistance);
    }
}
