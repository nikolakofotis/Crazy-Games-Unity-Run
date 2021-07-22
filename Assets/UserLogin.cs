using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
public class UserLogin : MonoBehaviour
{
    public GameObject login;
    public Text nameField, emailField;
    public Button submitButton;
    public InputField password;
    public GameObject success, fail;
    private MainMenuScript changeScene;
    public InputField loginUsername, loginPassword;
    public Button loginButton;
    public GameObject failLoginText;
    public bool fakeLogin;
    public User currentUser;


    void Start()
    {
        
    }

    
    void Update()
    {
        if (NullCheck(nameField.text) && NullCheck(emailField.text) && NullCheck(password.text))
        {
            submitButton.interactable = true;
        }
        else submitButton.interactable = false;


        if(NullCheck(loginUsername.text)&&NullCheck(loginPassword.text))
        {
            loginButton.interactable = true;
        }
        else
        {
            loginButton.interactable = false;
        }
    }

    private bool NullCheck(string t)
    {
        if (t != "")
        {
            return true;
        }
        else return false;
    }


    public void AlreadyHaveAccount()
    {
        login.SetActive(true);
    }

    public void GoBack()
    {
        login.SetActive(false);
    }

    public void GetData()
    {

    }

    public void  StartRegister()
    {
        StartCoroutine(Register());
    }
   private   IEnumerator Register()
    {
        WWWForm form = new WWWForm();
        form.AddField("username", nameField.text);
        form.AddField("password", password.text);
        form.AddField("email", emailField.text);

        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost/UnityServer/MakeAccountCheck.php", form))
        {
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(www.error);
            }
            else
            {
                StartCoroutine(currentUser.FetchUsers("http://localhost/UnityServer/FetchUser.php", nameField.text));
                Debug.Log("Form upload complete!");
                CheckHandler(www.downloadHandler.text,"r");
                
            }
        }

    }

    private void CheckHandler(string handlerText , string register)
    {
        if (register == "r")
        {
            if (handlerText == "ok")
            {
                success.SetActive(true);
                fail.SetActive(false);
                StartCoroutine(MoveToMain());
            }
            else
            {
                fail.SetActive(true);
                success.SetActive(false);
            }
        }
        else
        {
            if (handlerText == "ok")
            {
                currentUser.FetchUsersHelp("http://localhost/UnityServer/FetchUser.php", loginUsername.text);
                StartCoroutine(MoveToMain());
            }
            else
            {
                StartCoroutine(FailedLogin());
            }
        }
    }

    private IEnumerator FailedLogin()
    {
        failLoginText.SetActive(true);
        yield return new WaitForSeconds(5f);
        failLoginText.SetActive(false);
    }

    private IEnumerator MoveToMain()
    {
        yield return new WaitForSeconds(1f);
        changeScene = GameObject.Find("ScriptManager").GetComponent<MainMenuScript>();
        changeScene.OpenScreens(0);

    }

    public void MakeLogin()
    {
        StartCoroutine(Login());
    }
    private IEnumerator Login()
    {
        if (fakeLogin)
        { 
            if(loginUsername.text=="admin" && loginPassword.text=="root")
            {
                CheckHandler("ok", "");
            }
            else
            {
                StartCoroutine(FailedLogin());
            }
        }
        else
        {
            WWWForm form = new WWWForm();
            form.AddField("username", loginUsername.text);
            form.AddField("password", loginPassword.text);


            using (UnityWebRequest www = UnityWebRequest.Post("http://localhost/UnityServer/Login.php", form))
            {
                yield return www.SendWebRequest();

                if (www.result != UnityWebRequest.Result.Success)
                {
                    Debug.Log(www.error);
                }
                else
                {
                    Debug.Log("Form upload complete!");
                    CheckHandler(www.downloadHandler.text, "");

                }
            }

        }
    }

}
