using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene( "sampleSceneBirk");    }

    public void QuitGame()
    {
        Debug.Log("QUIT!");
        Application.Quit();
    }
}