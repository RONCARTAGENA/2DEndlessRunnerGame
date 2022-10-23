using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    private Transform player;

    private Vector3 tempPos;

    [SerializeField]
    private float Minx;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        //current position of the camera
        tempPos = transform.position;
        tempPos.x = player.position.x;

        transform.position = tempPos;

        if (tempPos.x < Minx)

            tempPos.x = Minx;

        transform.position = tempPos;
    }
}
