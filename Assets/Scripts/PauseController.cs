using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class PauseController : MonoBehaviour
{
    public static bool GameIsPaused = false;

    public GameObject pauseMenuUI;
    public GameObject loseMenuUI;
    public GameObject winMenuUI;

    public TextMeshProUGUI livesText;
    private HeathSystem health;
    public GameObject Enemy;

    // Start is called before the first frame update
    void Start()
    {
        Resume();
        health = Enemy.GetComponent<HeathSystem>();
        CurrentLives();
    }

    // Update is called once per frame
    void Update()
    {
        CurrentLives();
        //pause or unpause with keyboard key
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else if (Time.timeScale != 0f)
            {
                Pause();
            }
        }

        if (Data.hasBook == true)
        {
            Win();
        }
        if(health.lives <=0)
        {
          Invoke(nameof(Lose), 0.9f);
        }
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;

        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void Win()
    {
        winMenuUI.SetActive(true);
        Time.timeScale = 0f;

        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void Lose()
    {
        loseMenuUI.SetActive(true);
        Time.timeScale = 0f;

        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void Menu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void QuitGame()
    {
        Debug.Log("QUIT");
        Application.Quit();
    }
    void CurrentLives()
    {
        livesText.text = "Lives: " + health.lives;
    }
}
