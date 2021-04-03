using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Login : MonoBehaviour
{
    public InputField nameField;
    public InputField passwordField;

    public Button submitButton;

    public void CallLogin()
    {
        StartCoroutine(LoginPlayer());
    }

    IEnumerator LoginPlayer()
    {
        WWWForm form = new WWWForm();
        form.AddField("name", nameField.text);
        form.AddField("password", passwordField.text);
        //sending name/password to the server
        WWW www = new WWW("http://localhost/sqlconnect/login.php", form);
        yield return www;
        if(www.text[0] == '0')
        {
            DBManager.username = nameField.text;
            //splitting the text between echo calls from the server. Looking for error codes and information.
            DBManager.score = int.Parse(www.text.Split('\t')[1]);
            UnityEngine.SceneManagement.SceneManager.LoadScene("Main");
        }
        else
        {
            Debug.Log("User login failed. Error #" + www.text);
        }
    }
    public void VerifyInputs()
    {
        // username/password must be longer than 8 characters.
        submitButton.interactable = (nameField.text.Length >= 8 && passwordField.text.Length >= 8);
    }

}
