using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    public MovementScript ms;

    public MovementScriptPlayer2 msSwing;
    // Start is called before the first frame update
    void Start()
    {
        ms = GetComponentInParent<MovementScript>();
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
            if (Input.GetKeyDown(KeyCode.Space))
            {

                ms.Jumping();

            } 
            
            if (Input.GetKey(KeyCode.S))
            {
                ms.animScript.anchored = true;
                msSwing.swinging = true;
                ms.rb.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezePositionY|RigidbodyConstraints2D.FreezeRotation;
                //rend.material.color = Color.red;
            
           

            }
            if (Input.GetKeyUp(KeyCode.S))
            {
                msSwing.swinging = false;
                ms.rb.constraints = RigidbodyConstraints2D.FreezeRotation;
                ms.animScript.anchored = false;
                //rend.material.color = Color.white;
            }

            ms.grounded = true;
        }
        
        
      
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("ground") || other.gameObject.CompareTag("Player"))
        {
            ms.grounded = false;
        }
    }
}
