using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Net;
using System.Net.Mail;
using UnityEngine.UI;
using System.Security.Cryptography.X509Certificates;
using System.Net.Security;
using UnityEngine.Networking;

public class GameSettings : MonoBehaviour
{
    public MainMenuScript main;
    public GameObject reportPage;
    public GameObject playerReport, bugReport;
    public InputField bugInput;
    public Dropdown gamesDropdown;
    public Button bugSubmitButton;
    private string gameString, gameInputF;
    private string[] game = { "Crazy Plane","Minesweeper","Chess","Three in a line","Cards" };

    public Button reportPlayerButton;
    public InputField nameInputPR, reportFieldPR;
    private bool userFound;
    public Text foundUser;

    private void Start()
    {
        userFound = false;
    }

    void Update()
    {
        if(bugInput.text=="")
        {
            bugSubmitButton.interactable = false;
        }
        else
        {
            bugSubmitButton.interactable = true;
        }


        if(nameInputPR.text!="" && reportFieldPR.text!="" && userFound)
        {
            reportPlayerButton.interactable = true;
        }
        else
        {
            reportPlayerButton.interactable = false;
        }
    }

    public  void OpenReportPage()
    {
        reportPage.SetActive(true);
    }


    
    public void GameReport()
    {
        gameString = game[gamesDropdown.value];
        gameInputF = bugInput.text;
        MailMessage message = new MailMessage();
        message.To.Add("nikolakofotis@gmail.com");
        message.Subject="Bug report for " + gameString;
        message.Body = gameInputF;
        SmtpClient smtpServer = new SmtpClient("smtp.gmail.com");
        smtpServer.Port = 587;
        smtpServer.Credentials = new System.Net.NetworkCredential("nikolakofotis@gmail.com", "mypassword") as ICredentialsByHost;
        smtpServer.EnableSsl = true;
        ServicePointManager.ServerCertificateValidationCallback = delegate (object s, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
            {
                return true; 
            };
        smtpServer.Send(message);
        


    }

    
    public void PlayerReport()
    {

        MailMessage message = new MailMessage();
        message.To.Add("nikolakofotis@gmail.com");
        message.Subject = "Player report for " + nameInputPR.text;
        message.Body = reportFieldPR.text;
        SmtpClient smtpServer = new SmtpClient("smtp.gmail.com");
        smtpServer.Port = 587;
        smtpServer.Credentials = new System.Net.NetworkCredential("nikolakofotis@gmail.com", "mypassword") as ICredentialsByHost;
        smtpServer.EnableSsl = true;
        ServicePointManager.ServerCertificateValidationCallback = delegate (object s, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
        {
            return true;
        };
        smtpServer.Send(message);

    }

    public void CheckName()
    {
        StartCoroutine(OnEditName());
    }

    public IEnumerator OnEditName()
    {
        WWWForm form = new WWWForm();
        form.AddField("username", nameInputPR.text);



        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost/UnityServer/CheckUser.php", form))
        {
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(www.error);
            }
            else
            {
                Debug.Log("Form upload complete!");
                print(www.downloadHandler.text);
                if(www.downloadHandler.text=="ok")
                {
                    userFound = true;
                    foundUser.text = "";
                    
                }
                else
                {
                    userFound = false;
                    foundUser.text = "Ο χρήστης " + nameInputPR.text + " δεν υπάρχει.";
                }


            }
        }
    }

    public void BackToMain()
    {
        if(playerReport.activeSelf || bugReport.activeSelf )
        {
            playerReport.SetActive(false);
            bugReport.SetActive(false);
        }
        else if(reportPage.activeSelf)
        {
            reportPage.SetActive(false);
        }
        else
        {
            main.OpenScreens(0);
        }

    }

    public void OpenPlayerReport()
    {
        playerReport.SetActive(true);
    }

    public void OpenBugReport()
    {
        bugReport.SetActive(true);
    }

    public void OpenReport()
    {
        reportPage.SetActive(true);
    }





}
