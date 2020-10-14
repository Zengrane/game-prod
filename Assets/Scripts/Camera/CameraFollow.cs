using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform playerTransform; //Gets the player's transform

    public float offset;

    public float leftLimit = 600f;
    public float rightLimit = 2400f;

    public float smoothSpeed = 0.125f;

    // called after update and fixed update
    void LateUpdate()
    {
        Vector3 temp = transform.position;

        temp.x = playerTransform.position.x; 

        temp.x += offset;

        temp.x = Mathf.Clamp(playerTransform.position.x, leftLimit, rightLimit);

        transform.position = temp;

        
    }
}
