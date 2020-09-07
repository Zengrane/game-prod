using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PrimaryProjectile", menuName = "PixelArt/PrimaryProjectile")]
public class PrimaryProjectile : ScriptableObject
{
    public GameObject projectile;
    public float speed;
    public float damage;

   
}
