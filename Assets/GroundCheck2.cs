using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck2 : MonoBehaviour
{
    public MovementScriptPlayer2 ms;

    public MovementScript msSwing;
    public float jumpCoolDown;
    private float jumpCoolDownInitial;

    public bool jumping;
    
    public KeyCode jump, anchor;
    // Start is called before the first frame update
    void Start()
    {
        jumpCoolDownInitial = jumpCoolDown;
        ms = GetComponentInParent<MovementScriptPlayer2>();
    }

    // Update is called once per frame
    void Update()
    {
        if (jumping)
        {
            jumpCoolDown += Time.deltaTime;
        }

        if (jumpCoolDown >= jumpCoolDownInitial)
        {
            jumping = false;
        }
    }
    
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("ground")||other.gameObject.CompareTag("Player"))
        {
            ms.rb.velocity = new Vector3(ms.x * ms.speed, ms.rb.velocity.y, 0);
            if (Input.GetKeyDown(KeyCode.UpArrow)||Input.GetKey(jump) && !jumping)
            {

                ms.Jumping();
                jumping = true;
                jumpCoolDown = 0;

            } 
            
            if (Input.GetKey(KeyCode.DownArrow)||Input.GetKeyDown(anchor))
            {
                msSwing.swinging = true;
                msSwing.animScript.isSwinging = true;
                ms.animScript.anchored = true;
                ms.rb.constraints = RigidbodyConstraints2D.FreezePositionX |RigidbodyConstraints2D.FreezeRotation;
                //rend.material.color = Color.red;
            
           

            }
            else// (Input.GetKeyUp(KeyCode.DownArrow))
            {
                msSwing.swinging = false;
                msSwing.animScript.isSwinging = false;
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
            msSwing.swinging = false;
            ms.rb.constraints = RigidbodyConstraints2D.FreezeRotation;
            ms.animScript.anchored = false;
        }
    }
}
