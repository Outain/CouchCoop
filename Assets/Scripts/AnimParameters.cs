using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimParameters : MonoBehaviour
{
    
    public KeyCode Left = KeyCode.A;
    public KeyCode Right = KeyCode.D;

    Animator anim;
    public bool isJumping, isSwinging;
    bool moving;
    public bool anchored;
    public string playerAxis;

    void Start()
    {
        anim = GetComponent<Animator>();
        moving = false;
    }
    
    void Update()
    {
       
        if (Input.GetKey(Left) || Input.GetKey(Right)||Input.GetAxis(playerAxis)!=0)
        {
            moving = true;
        }
        else
        {
            moving = false;
        }

        anim.SetBool("Move", moving);
        if (Input.GetKey(Left)||Input.GetAxis(playerAxis)<0)
        {
            transform.localScale = new Vector3(-1,1,1);
        }
        if (Input.GetKey(Right)||Input.GetAxis(playerAxis)>0)
        {
            transform.localScale = new Vector3(1,1,1);
        }

        if (isJumping)
        {
            anim.SetBool("Jump", true);
        }
        else
        {
            anim.SetBool("Jump", false);
        }

        if (anchored)
        {
            anim.SetBool("Anchor", true);
        }
        else
        {
            anim.SetBool("Anchor", false);
        }

        if (isSwinging)
        {
            anim.SetBool("Swinging",true);
        }
        else
        {
            anim.SetBool("Swinging",false);
        }
    }


}
