using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPointSwitcher : MonoBehaviour
{
    public GameObject spawnPoint;

    public Transform spawnPoint1, spawnPoint2;
    // Start is called before the first frame update
    void Start()
    {
        spawnPoint.transform.position = spawnPoint1.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            spawnPoint.transform.position = spawnPoint2.position;
        }
    }
}
