using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class User : MonoBehaviour
{
    public string currentUsername, currentEmail;
    public int currentLives, currentScore,id;

   

    
    void Start()
    {
        //StartCoroutine(FetchUsers("http://localhost/UnityServer/FetchUser.php", "fotis"));
    }

    
    void Update()
    {
        
    }

    public void SetCurrentUser(string uname, string e_mail, int live, int sc , int id)
    {
        this.currentUsername = uname;
        this.currentEmail = e_mail;
        this.currentLives = live;
        this.currentScore = sc;
        this.id = id;
    }

    public void  FetchUsersHelp(string uri, string username)
    {
        StartCoroutine(FetchUsers(uri, username));
    }
    public IEnumerator FetchUsers(string uri, string username)
    {
        WWWForm form = new WWWForm();
        form.AddField("username", username);
        


        using (UnityWebRequest www = UnityWebRequest.Post(uri, form))
        {
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(www.error);
            }
            else
            {
                Debug.Log("Form upload complete!");
               
                SplitString(www.downloadHandler.text);
                

            }
        }
    }

    private void SplitString(string s)
    {
        string[] userD ;
        userD = s.Split('/');
       SetCurrentUser(userD[1], userD[2], int.Parse( userD[3]), int.Parse(userD[4]),int.Parse(userD[5]));
        print(userD[1]);
        


    }
}



