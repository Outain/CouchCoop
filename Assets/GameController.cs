using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
   private OpenDoor[] doorScripts;
    // Start is called before the first frame update
    void Start()
    {
       doorScripts = FindObjectsOfType(typeof(OpenDoor)) as OpenDoor[];
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ResetAllDoors()
    {
        for (int i = 0; i < doorScripts.Length; i++)
        {
            doorScripts[i].ResetPosition();
        }
    }
    
}
