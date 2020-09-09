using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{   
    public PrimaryProjectile projectile;
    public Transform shotPoint;

    private float timeShots;
    public float startTimeShots;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {   
        if (timeShots <= 0)
        {
            if (Input.GetKeyDown("space"))
            {   
                GameObject go = Instantiate(projectile.projectile, shotPoint.position, transform.rotation);

                Projectile proj = go.GetComponent<Projectile>();

                proj.speed = projectile.speed;


               timeShots = startTimeShots;
            }
        }
        else
        {
            timeShots -= Time.deltaTime;
        }

        
    }
}
