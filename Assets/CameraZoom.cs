using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoom : MonoBehaviour
{
    int zoom = 20;
    int normal = 7;
    float smooth = 5;

    private bool isZoomed = false;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.M))
        {
            isZoomed = !isZoomed;
        }

        if(isZoomed)
        {
            GetComponent<Camera>().orthographicSize = Mathf.Lerp(GetComponent<Camera>().orthographicSize, zoom, Time.deltaTime * smooth);
        }

        else
        {
            GetComponent<Camera>().orthographicSize = Mathf.Lerp(GetComponent<Camera>().orthographicSize, normal, Time.deltaTime * smooth);
        }
    }
}
