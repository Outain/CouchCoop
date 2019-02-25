using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimParameters : MonoBehaviour
{
    
    public KeyCode Left = KeyCode.A;
    public KeyCode Right = KeyCode.D;

    Animator anim;

    bool moving;

    void Start()
    {
        anim = GetComponent<Animator>();
        moving = false;
    }
    
    void Update()
    {
       
        if (Input.GetKey(Left) || Input.GetKey(Right))
        {
            moving = true;
        }
        else
        {
            moving = false;
        }

        anim.SetBool("Move", moving);
    }


}
