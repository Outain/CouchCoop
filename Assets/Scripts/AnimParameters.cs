using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimParameters : MonoBehaviour
{

    public KeyCode move = KeyCode.A;
    public Animator anim;

    bool moving;

    void Start()
    {
        anim = GetComponent<Animator>();
        moving = false;
    }
    
    void Update()
    {
        if (Input.GetKey(move))
        {
            moving = true;
        } else
        {
            moving = false;
        }

        anim.SetBool("Move", moving);
    }


}
