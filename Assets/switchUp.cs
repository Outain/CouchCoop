using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class switchUp : MonoBehaviour
{
    public AudioSource musicPlaying;

    public AudioClip newSong;

    public Image blackScreen;

    public float fadeSpeed = 5f;

    public bool reset;

    // Start is called before the first frame update
    void Start()
    {
        reset = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (reset)
        {
            var tempColor = blackScreen.color;
            tempColor.a -= Time.deltaTime * fadeSpeed;
            blackScreen.color = tempColor;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            musicPlaying.clip = newSong;
            
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            var tempColor = blackScreen.color;
            tempColor.a += Time.deltaTime * fadeSpeed;
            blackScreen.color = tempColor;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (!reset)
            {
                musicPlaying.Play();
            }
            reset = true;
            
        }
    }
}
