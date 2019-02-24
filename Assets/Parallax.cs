using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    public bool scrolling, parallax;
    public float backgroundSize;

    private Transform cameraT;
    private Transform[] layers;
    private float viewZone = 10;
    private int leftIndex;
    private int rightIndex;

    public float parallaxSpeed;
    private float lastCameraX;

    private void Start()
    {
        cameraT = Camera.main.transform;
        lastCameraX = cameraT.position.x;
        layers = new Transform[transform.childCount];
        for(int i = 0; i < transform.childCount; i++)
        {
            layers[i] = transform.GetChild(i);
        }
        leftIndex = 0;
        rightIndex = layers.Length-1;
    }

    private void Update()
    {
        if (parallax)
        {
            float deltaX = cameraT.position.x - lastCameraX;
            transform.position += Vector3.right * (deltaX * parallaxSpeed);
        }

        lastCameraX = cameraT.position.x;

        if (scrolling)
        {
            if (cameraT.position.x < (layers[leftIndex].transform.position.x + viewZone))
            {
                ScrollLeft();
            }

            if (cameraT.position.x > (layers[rightIndex].transform.position.x - viewZone))
            {
                ScrollRight();
            }
        }
    }

    private void ScrollLeft()
    {
        int lastRight = rightIndex;
        layers[rightIndex].position = new Vector3(1 * layers[leftIndex].position.x - backgroundSize, layers[leftIndex].position.y, 0);
        leftIndex = rightIndex;
        rightIndex--;
        if(rightIndex < 0)
        {
            rightIndex = layers.Length - 1;
        }
    }

    private void ScrollRight()
    {
        int lastLeft = leftIndex;
        layers[leftIndex].position = new Vector3(1 * layers[rightIndex].position.x - backgroundSize, layers[rightIndex].position.y, 0);
        rightIndex = leftIndex;
        leftIndex++;
        if(leftIndex == layers.Length)
        {
            leftIndex = 0;
        }
    }
}
