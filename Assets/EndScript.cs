using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndScript : MonoBehaviour
{
    public bool turnedOn;
    public float fadeSpeed;
    public Image greyScreen;

    public Text endText;
    public AudioSource music;

    // Start is called before the first frame update
    void Start()
    {
        turnedOn = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (turnedOn)
        {
            var tempColor = greyScreen.color;
            tempColor.a += Time.deltaTime * fadeSpeed;
            greyScreen.color = tempColor;
            var textColor = endText.color;
            textColor.a += Time.deltaTime * fadeSpeed;
            endText.color = textColor;
            music.volume -= Time.deltaTime * fadeSpeed;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            turnedOn = true;
            GameController.finalTime = Mathf.RoundToInt(GameController.time);
        }
    }
}
