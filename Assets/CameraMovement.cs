using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform player1, player2;

    public Vector3 halfWayPoint;

    private Vector3 cameraPos;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        halfWayPoint = player1.position + (player2.position - player1.position) / 2;
        cameraPos = new Vector3(halfWayPoint.x,halfWayPoint.y,-10);
        transform.position = cameraPos;
    }
}
