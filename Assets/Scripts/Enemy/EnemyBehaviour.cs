using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    public float hitpoints;
    public float maxHitPoints = 5;
    public HealthbarBehaviour healthbar;

    // Start is called before the first frame update
    void Start()
    {
        hitpoints = maxHitPoints;
        healthbar.SetHealth(hitpoints, maxHitPoints);
    }

    public void TakeHit(float damage)
    {
        hitpoints -= damage;
        
        if (hitpoints <= 0)
        {
            Destroy(gameObject);
        }


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
