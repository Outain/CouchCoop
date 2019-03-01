using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class GameController : MonoBehaviour
{
   private OpenDoor[] doorScripts;
   public EndScript eS;
   public static float time;

   public Text timeText;
   public int timeToDisplay;

   public static int finalTime;
    // Start is called before the first frame update
    void Start()
    {
        time = 0;
        finalTime = 0;
       doorScripts = FindObjectsOfType(typeof(OpenDoor)) as OpenDoor[];
    }

    // Update is called once per frame
    void Update()
    {
        if (!eS.turnedOn)
        {
            time += Time.deltaTime;
        }
     
        if (Input.GetKey(KeyCode.R))
        {
            Scene scene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(scene.name);
        }

        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }

        timeToDisplay = Mathf.RoundToInt(time);
        timeText.text = "Time:" + " " + timeToDisplay;
    }

    public void ResetAllDoors()
    {
        for (int i = 0; i < doorScripts.Length; i++)
        {
            doorScripts[i].ResetPosition();
        }
    }
    
}
