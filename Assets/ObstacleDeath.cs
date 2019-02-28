using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleDeath : MonoBehaviour
{
    private GameObject originalPlayer;
    public GameObject player;
    public GameObject startPos;
    private Vector3 spawnTransform;
    public GameController gcScript;
    void Start()
    {
        startPos = GameObject.FindWithTag("spawn");
        print(startPos.transform.position);
        spawnTransform = transform.position - startPos.transform.position;
    }

    void update()
    {
        spawnTransform = startPos.transform.position- transform.position;
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Obstacle")
        {
            Debug.Log("Hit");
            //Instantiate(player, spawnTransform, Quaternion.identity);
           player.transform.position = startPos.transform.position - transform.localPosition;
            //Destroy(this.transform.parent.gameObject);
            gcScript.ResetAllDoors();
            
        }
    }
}
