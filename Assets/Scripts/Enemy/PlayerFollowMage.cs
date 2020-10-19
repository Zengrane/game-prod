using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFollowMage : PlayerFollow
{
    public int burstCount;
    public float timeBetweenShots;

    public override void Shoot(Vector3 target)
    {
        StartCoroutine(nameof(ShootBurst), target); //Coroutines allow functions to be run over multiple frames

    }

    IEnumerator ShootBurst(Vector3 target) //IEnumerator refers to a coroutine
    {
        for (int i = 0; i < burstCount; i++)
        {
            GameObject proj = Instantiate(enemyProj, enemyProjParent.transform.position, Quaternion.identity);

            proj.transform.up = target - transform.position;

            yield return new WaitForSeconds(timeBetweenShots); //Yield is used to continue a function without restarting, allows the time between shots to be modified
        }
    }
    


}
