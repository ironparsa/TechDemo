using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    //inital state should be false for being paused
    public static bool GameIsPaused = false;

    public GameObject pauseMenuUI;

    public void Start()
    {
        Resume();
    }

    void Update()
    {
        //logic for pausing the game using escape key
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            //unlocks the mouse from the game screen
            Cursor.lockState = CursorLockMode.None;
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    //Resume the game from exiting the pause menu
    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
    //pause the game from after pressing escape
    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }
}
