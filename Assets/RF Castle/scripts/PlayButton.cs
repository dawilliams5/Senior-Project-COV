using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayButton: MonoBehaviour
{
    public Scene nextScene;
    public void play()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
       
    }

    public void quit()
    {
        Application.Quit();
        Debug.Log("Player has quit the game");
    }
}
