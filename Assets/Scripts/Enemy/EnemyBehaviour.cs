using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyBehaviour : MonoBehaviour
{
    public float hitpoints;
    public float maxHitPoints = 5;
    public Image healthBarFill;

    // Start is called before the first frame update
    void Start()
    {
        hitpoints = maxHitPoints;
    }

    public void TakeHit(float damage)
    {
        hitpoints -= damage;
        
        if (hitpoints <= 0)
        {
            Destroy(gameObject);
        }

        healthBarFill.fillAmount = hitpoints / maxHitPoints;


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
