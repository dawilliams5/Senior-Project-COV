using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadOptions : MonoBehaviour
{
    public void LoadOptionsMenu()
    {
        SceneManager.LoadScene("OptionsMenu");
    }

    public void LoadGame()
    {
        SceneManager.LoadScene("Demo");
    }
}
