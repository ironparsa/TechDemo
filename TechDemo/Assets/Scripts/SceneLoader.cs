using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneLoader : MonoBehaviour
{
    public void _2dScene()
    {
        Debug.Log("Switching to 2D Scene");
        SceneManager.LoadScene("2d");
    }
    public void _3dScene()
    {
        Debug.Log("Switching to 3D Scene");
        SceneManager.LoadScene("3d");
    }    
    public void MainMenuScene()
    {
        Debug.Log("Switching to Main Menu");
        SceneManager.LoadScene("Main");
    }
    public void QuitGame() 
    {
        Debug.Log("Quitting game");
        Application.Quit();
    }
    

}
