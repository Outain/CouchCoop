using System.Collections;
using System.Collections.Generic;
using UnityEditor.Android;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    public GameObject door;
    public bool _pressed;
    public Transform openDoorPos;
    public float doorOpenSpeed, switchOpenSpeed;
    public bool destroyObject;
    public GameObject objectToDestroy;
    
    
    private Vector2 _pressedSwitchTransform,_originalSwitchTransform;

    public bool linkedSwitch;

    public GameObject switchToLink;
    // Start is called before the first frame update
    void Start()
    {
        _originalSwitchTransform = transform.position;
        _pressed = false;
        _pressedSwitchTransform = new Vector2(transform.position.x, transform.position.y-0.2f);
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
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
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

    public void Pressed()
    {
        
    }
    
   
}
