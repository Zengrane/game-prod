using System.Collections;
using System.Collections.Generic;
using UnityEditor.IMGUI.Controls;
using UnityEngine;
using UnityEngine.UI;
public class Health : MonoBehaviour
{
    public float hitpoints;
    public float maxHitPoints = 3;

    private Rigidbody2D rb;

    public int health;
    public int numOfHearts;

    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;
    void Start()
    {
        hitpoints = maxHitPoints;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (health > numOfHearts)
        {
            health = numOfHearts;
        }
        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < health)
            {
                hearts[i].sprite = fullHeart;
            }
            else
            {
                hearts[i].sprite = emptyHeart;
            }
            if (i < numOfHearts)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }

        }
        if (health == 0)
        {
            Destroy(gameObject);
        }
    }

    public void TakeHit(float damage)
    {
        hitpoints -= damage;

        health = (int)hitpoints;


        if (hitpoints <= 0)
        {
            health = 0;
            
        }

       

        


    }
   

}
