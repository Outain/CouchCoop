using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleDeath : MonoBehaviour {

    /*private void OnTriggerEnter2D(Collider2D coll)
    {
        if(coll.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }
    }*/

    [SerializeField]private Transform player;
    [SerializeField]private Transform respawnPoint;

    private void OnTriggerEnter2D(Collider2D coll)
    {
        player.transform.position = respawnPoint.transform.position;
    }
}
