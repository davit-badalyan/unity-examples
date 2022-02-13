using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour
{
    public Transform player;
    public float smoothness = 0.125f;
    public Vector3 offset = new Vector3(0, 5, -10);

    private void FixedUpdate()
    {
        FollowPlayer();
    }

    private void FollowPlayer()
    {
        Vector3 desiredPos = player.position + offset;
        Vector3 smoothedPos = Vector3.Lerp(transform.position, desiredPos, smoothness);

        transform.LookAt(player);
        transform.position = smoothedPos;
    }
} 
