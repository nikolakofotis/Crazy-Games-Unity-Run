using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class EditUser : MonoBehaviour
{

    public InputField userInput, emailIpnut;
    public Text userTextField, emailTextField;
    public User user;
    public GameObject openUsername, openEmail;
    private void Awake()
    {
        userTextField.text = user.currentUsername;
        emailTextField.text = user.currentEmail;
    }
    



    public void OpenUsernameEdit()
    {
        openUsername.gameObject.SetActive(true);
        openEmail.gameObject.SetActive(false);
    }

    public void OpenEmailEdit()
    {
        openUsername.gameObject.SetActive(false);
        openEmail.gameObject.SetActive(true);
    }


    public void Close(GameObject g)
    {
        g.SetActive(false);
    }
    public void EditUsername()
    {
        StartCoroutine(MakeRequest(userInput.text, user.currentEmail));
    }

    public void EditEmail()
    {
        StartCoroutine(MakeRequest(user.currentUsername, emailIpnut.text));
    }

    public IEnumerator MakeRequest(string username,string email)
    {
        user.SetCurrentUser(username, email, user.currentLives, user.currentScore, user.id);
        userTextField.text = user.currentUsername;
        emailTextField.text = user.currentEmail;
        WWWForm form = new WWWForm();
        form.AddField("username",username);
        form.AddField("email", email);
        form.AddField("points", user.currentScore);
        form.AddField("lives", user.currentLives);
        form.AddField("id", user.id);


        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost/UnityServer/EditUser.php", form))
        {
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(www.error);
            }
            else
            {
                Debug.Log(www.downloadHandler.text);
                openUsername.gameObject.SetActive(false);
                openEmail.gameObject.SetActive(false);



            }
        }

    }
}
