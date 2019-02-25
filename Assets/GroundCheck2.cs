using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck2 : MonoBehaviour
{
    public MovementScriptPlayer2 ms;
    // Start is called before the first frame update
    void Start()
    {
        ms = GetComponentInParent<MovementScriptPlayer2>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("ground")||other.gameObject.CompareTag("Player"))
        {
            ms.rb.velocity = new Vector3(ms.x * ms.speed, ms.rb.velocity.y, 0);
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {

                ms.Jumping();

            } 
            
            if (Input.GetKey(KeyCode.DownArrow))
            {
                ms.animScript.anchored = true;
                ms.rb.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezePositionY|RigidbodyConstraints2D.FreezeRotation;
                //rend.material.color = Color.red;
            
           

            }
            if (Input.GetKeyUp(KeyCode.DownArrow))
            {
            
                ms.rb.constraints = RigidbodyConstraints2D.FreezeRotation;
                ms.animScript.anchored = false;
                //rend.material.color = Color.white;
            }
        }
        
        
      
    }
}
