using System.Collections;
using System.Collections.Generic;
using UnityEditor.Android;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    public GameObject door;
    public bool _pressed,_reset;
    public Transform openDoorPos;
    public float doorOpenSpeed, switchOpenSpeed;
    public bool destroyObject;
    public GameObject objectToDestroy;
    
    
    private Vector2 _pressedSwitchTransform,_originalSwitchTransform,_originalDoorTransform;

    public bool linkedSwitch;

    public GameObject switchToLink;
    // Start is called before the first frame update
    void Start()
    {
        _originalSwitchTransform = transform.position;
        _pressed = false;
        _pressedSwitchTransform = new Vector2(transform.position.x, transform.position.y-0.2f);
        _originalDoorTransform = door.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (_pressed)
        {
            transform.position = Vector2.Lerp(transform.position, _pressedSwitchTransform, switchOpenSpeed*Time.deltaTime);
            door.transform.position = Vector2.MoveTowards(door.transform.position, openDoorPos.position, doorOpenSpeed*Time.deltaTime);
            if (destroyObject)
            {
                if (objectToDestroy != null)
                {
                    Destroy(objectToDestroy);
                }
            }

           
        }

        if (!_pressed)
        {
            transform.position = Vector2.Lerp(transform.position, _originalSwitchTransform, switchOpenSpeed*Time.deltaTime);
        }
        
        if (_reset)
        {
            door.transform.position = Vector2.MoveTowards(door.transform.position, _originalDoorTransform, doorOpenSpeed*10*Time.deltaTime);

        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            _reset = false;
            _pressed = true;
            if (linkedSwitch)
            {
                if (switchToLink != null)
                {
                    switchToLink.GetComponent<OpenDoor>()._pressed = false;
                }
            }
        }
    }

    public void ResetPosition()
    {
        _pressed = false;
        _reset = true;
    }
    
   
}
