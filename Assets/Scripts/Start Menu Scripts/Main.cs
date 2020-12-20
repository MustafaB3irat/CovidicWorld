using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        FindObjectOfType<AudioManager>().Play("Entry Music Skyrim Sample");
        Invoke("playAlansGreeting", 4);
    }

    void playAlansGreeting()
    {
        FindObjectOfType<AudioManager>().Play("Alan Greeting");
    }

   public void playButtonSound()
    {
        FindObjectOfType<AudioManager>().Play("Button Clicked");
    }
}
