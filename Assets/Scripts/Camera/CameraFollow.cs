using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform playerTransform; //Gets the player's transform

    public float offset;

    public float leftLimit = 600f;
    public float rightLimit = 2400f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // called every frame
    private void Update()
    {
        
    }

    // called every fixed framerate
    private void FixedUpdate()
    {
        
    }
    // called after update and fixed update
    void LateUpdate()
    {
        Vector3 temp = transform.position; //Store current camera's position in variable temp

        temp.x = Mathf.Clamp(playerTransform.position.x, leftLimit, rightLimit); //Set the camera's position x to be equal to the player's x position

        temp.x += offset; //Will add offset value to temporary x position

        transform.position = temp; //Set back the camera's position back to camera's current position
    }
}
