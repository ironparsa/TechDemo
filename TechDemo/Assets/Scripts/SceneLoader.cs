using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneLoader : MonoBehaviour
{
    //switch to "2d" scene
    public void _2dScene()
    {
        Debug.Log("Switching to 2D Scene");
        SceneManager.LoadScene("2d");
    }
    //switch to "3d" scene
    public void _3dScene()
    {
        Debug.Log("Switching to 3D Scene");
        string scene = SceneManager.GetActiveScene().name;
        if (scene == "3d")
        {
            GameObject.Find("PauseMenu").SetActive(false);
            Time.timeScale = 1f;
            PauseMenu.GameIsPaused = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
        SceneManager.LoadScene("3d");
    }
    //switch to "MainMenu" scene
    public void MainMenuScene()
    {
        Debug.Log("Switching to Main Menu");
        // to make sure the game is not paused when returning to the mainmenu
        Time.timeScale = 1f;
        SceneManager.LoadScene("Main");
    }
    //switch to quit the game
    public void QuitGame() 
    {
        Debug.Log("Quitting game");
        Application.Quit();
    }
    

}
