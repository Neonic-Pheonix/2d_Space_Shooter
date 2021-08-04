using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameracontroller : MonoBehaviour
{
    public GameObject player;
    public Vector3 offset;

    void start() 
    {
        offset = transform.position;
    }
    void LateUpdate() 
    {
        transform.position = player.transform.position + offset;
    }
}
