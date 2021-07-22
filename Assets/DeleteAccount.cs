using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using System.Net.Mail;
using System.Security.Cryptography.X509Certificates;
using System.Net.Security;
using System.Net;


public class DeleteAccount : MonoBehaviour
{
    public User user;
    public InputField reasonsField;
    public Button deleteButton;
    public GameObject deleteBackgorund;
    public MainMenuScript main;
    
    void Start()
    {
        
    }

   

    void Update()
    {
        if(reasonsField.text=="")
        {
            deleteButton.interactable = false;
        }
        else
        {
            deleteButton.interactable = true;
        }
    }

    public void DeleteAccountOpen()
    {
        deleteBackgorund.SetActive(true);
    }

    public void DeleteAccountClose()
    {
        deleteBackgorund.SetActive(false);
    }

    public void SubmitDelete()
    {
        StartCoroutine(DeleteAcc());
    }
    public IEnumerator DeleteAcc()
    {
        WWWForm form = new WWWForm();
        form.AddField("username", user.currentUsername);

        /*MailMessage message = new MailMessage();
        message.To.Add("nikolakofotis@gmail.com");
        message.Subject = "Deleted account by  " + user.currentUsername;
        message.Body = reasonsField.text;
        SmtpClient smtpServer = new SmtpClient("smtp.gmail.com");
        smtpServer.Port = 587;
        smtpServer.Credentials = new System.Net.NetworkCredential("nikolakofotis@gmail.com", "mypassword") as ICredentialsByHost;
        smtpServer.EnableSsl = true;
        ServicePointManager.ServerCertificateValidationCallback = delegate (object s, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
        {
            return true;
        };
        smtpServer.Send(message);*/

        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost/UnityServer/DeleteAccount.php", form))
        {
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(www.error);
            }
            else
            {

                print(www.downloadHandler.text);
                CheckIfDeleted(www.downloadHandler.text);

            }
        }
    }

    public void CheckIfDeleted(string text)
    {
        if(text=="ok")
        {
            main.OpenScreens(6);
        }
        else
        {
            print("failed to delete user");
        }
    }
}
