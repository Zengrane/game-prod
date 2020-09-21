using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFollow : MonoBehaviour
{
    public float speed;
    public float stoppingDistance;
    public float lineOfSite;

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
            if (Vector2.Distance(transform.position, target.position) > stoppingDistance)
            {
                if(transform.position.x < target.position.x) //If the enemy position is less than x, the enemy moves right
                {
                    rb2d.velocity = new Vector2(speed, 0);
                    transform.localScale = new Vector2(1.5f, 1.5f);

                }

                else if(transform.position.x > target.position.x) //If the enemy position is greater than x, the enemy moves left
                {
                    rb2d.velocity = new Vector2(-speed, 0);
                    transform.localScale = new Vector2(-1.5f, 1.5f);
                }

            }
        }


     
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, lineOfSite);
    }
}
