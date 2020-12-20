using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager: MonoBehaviour
{
    bool gameHasEnded = false;

   public void EndGame()
    {
        if (!gameHasEnded)
        {
            Debug.Log("Ended Suasdada");
            gameHasEnded = true;
            Invoke("Restart", 5);
        }
    }

    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
