using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ScoringSystem : MonoBehaviour
{
   public int score = 0;

    void OnTriggerEnter(Collider other)
    {
        FindObjectOfType<AudioManager>().Play("coin sfx");
        score++;
        GameObject.Find("Score").GetComponent<Text>().text = "Score: " + score;
        Destroy(gameObject);
    }

}
