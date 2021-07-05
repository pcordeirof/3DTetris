using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour
{
    [SerializeField] private Spawner spawner;
    public GridSettings gridSettings;

    public GameObject pauseMenuUI;
    public GameObject gameOverMenuUI;
    public static bool isPaused = false;

    //public AudioManager audioManager;


    void Start()
    {
        gridSettings.InstatiateGrid();
        spawner.SpawnNewPiece();
        pauseMenuUI.SetActive(false);
        gameOverMenuUI.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
        //audioManager.ChangeVolume("BGMusic", .205f);
    }

    void Update()
    {
        if (Input.GetButtonDown("Submit") && isPaused == false)
        {
            PauseGame();
        }
        else if (Input.GetButtonDown("Submit") && isPaused == true)
        {
            UnpauseGame();
        }
    }
    public void GameOverMenu()
    {
        gameOverMenuUI.SetActive(true);
        isPaused = true;
        Time.timeScale = 0f;
        //audioManager.ChangeVolume("BGMusic", .05f);
    }

    public void RestartScene()
    {
        SceneManager.LoadScene(1);
        pauseMenuUI.SetActive(false);
        gameOverMenuUI.SetActive(false);
        isPaused = false;
        Time.timeScale = 1f;
        //audioManager.ChangeVolume("BGMusic", .205f);
    }

    public void PauseGame()
    {
        pauseMenuUI.SetActive(true);
        isPaused = true;
        Time.timeScale = 0f;
        //audioManager.ChangeVolume("BGMusic", .05f);
    }

    public void UnpauseGame()
    {
        pauseMenuUI.SetActive(false);
        gameOverMenuUI.SetActive(false);
        isPaused = false;
        Time.timeScale = 1f;
        //audioManager.ChangeVolume("BGMusic", .205f);
    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1f;
        //audioManager.ChangeVolume("BGMusic", .205f);
    }

    [Button("Spawn New Piece")]
    void Spawn()
    {
        spawner.SpawnNewPiece();
    }
}
