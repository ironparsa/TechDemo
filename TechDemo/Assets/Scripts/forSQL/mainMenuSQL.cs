using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class mainMenuSQL : MonoBehaviour
{
    public Text playerDisplay;
    public Button playBtn;

    public void Start()
    {
        if (DBManager.LoggedIn)
        {
            playerDisplay.text = "Player: " + DBManager.username;
            Debug.Log("test??");
            playBtn.interactable = true;
        }
    }

    public void GoToRegister()
    {
        SceneManager.LoadScene("registermenu");
    }

    public void GoToLogin()
    {
        SceneManager.LoadScene("loginmenu");
    }
}
