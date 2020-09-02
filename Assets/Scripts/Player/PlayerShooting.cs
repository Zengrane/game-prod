using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public GameObject projectile;
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
                Instantiate(projectile, shotPoint.position, transform.rotation);
                timeShots = startTimeShots;
            }
        }
        else
        {
            timeShots -= Time.deltaTime;
        }
        
    }
}
