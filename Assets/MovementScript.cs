﻿using UnityEngine;
using System.Collections;

public class MovementScript : MonoBehaviour {

    public float speed;
    public float jump;
    public GameObject rayOrigin;
    public float rayCheckDistance;
    public Rigidbody2D rb;
    public Renderer rend;
    
    public AnimParameters animScript;
 
   private void Start () {
        rb = GetComponent <Rigidbody2D> ();
    }
 
   private void FixedUpdate () {
        float x = Input.GetAxis ("Horizontal");
//        if (Input.GetKeyDown(KeyCode.Space)) {
//            RaycastHit2D hit = Physics2D.Raycast(rayOrigin.transform.position, Vector2.down, rayCheckDistance);
//            if (hit.collider.CompareTag("ground")||hit.collider.CompareTag("Player")) {
//                rb.AddForce (Vector2.up * jump, ForceMode2D.Impulse);
//            }
//        }
        rb.velocity = new Vector3 (x * speed, rb.velocity.y, 0);
//
//        if (Input.GetKeyDown(KeyCode.S))
//        {
//            RaycastHit2D hit = Physics2D.Raycast(rayOrigin.transform.position, Vector2.down, rayCheckDistance);
//            if (hit.collider.CompareTag("ground")) {
//                rb.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezePositionY|RigidbodyConstraints2D.FreezeRotation;
//                rend.material.color = Color.red;
//            }
//           
//
//        }
//         if (Input.GetKeyUp(KeyCode.S))
//        {
//            
//            rb.constraints = RigidbodyConstraints2D.FreezeRotation;
//            animScript.anchored = false;
//            rend.material.color = Color.white;
//        }

         if (rb.velocity.y > 0.1f)
         {
            animScript.isJumping = true;
         }
         else
         {
            animScript.isJumping = false;
         }
    }

  

   public void Jumping()
   {
       rb.AddForce (Vector2.up * jump, ForceMode2D.Impulse);
   }
}

