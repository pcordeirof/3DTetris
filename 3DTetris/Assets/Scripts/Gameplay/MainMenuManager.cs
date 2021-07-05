using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public AudioManager audioManager;

    void Start()
    {
        audioManager.ChangeVolume("BGMusic", .1f); 
    }
    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void Instructions()
    {
        SceneManager.LoadScene(2);
    }
}
