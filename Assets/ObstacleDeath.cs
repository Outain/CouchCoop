using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleDeath : MonoBehaviour
{
    public GameObject player;
    public Transform startPos;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Obstacle")
        {
            Debug.Log("Hit");
            player.transform.position = startPos.transform.position;
        }
    }
}
