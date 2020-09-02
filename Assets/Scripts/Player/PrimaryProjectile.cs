using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PrimaryProjectile", menuName = "PixelArt/PrimaryProjectile")]
public class PrimaryProjectile : ScriptableObject
{
    public Sprite sprite;
    public float speed;
    public float damage;

}
