using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class User : MonoBehaviour
{
    public string currentUsername, currentEmail;
    public int currentLives, currentScore,id;
    public List<Games> gamesPlayed = new List<Games>();
    public int platformer, action, puzzle, strategy, rpg, sports, adventure, racing, card;
    public Dictionary<string, int> genres = new Dictionary<string, int>();

   

    
    void Start()
    {
        //StartCoroutine(FetchUsers("http://localhost/UnityServer/FetchUser.php", "fotis"));
        
    }

    
    void Update()
    {
        
    }

    public void AddGame(string s)
    {
       if(!genres.ContainsKey(s))
        {
            genres.Add(s, 1);
        }
       else
        {
           
            genres[s]++;
        }
       
    }

    public void GetValues()
    {
        platformer = genres["platformer"]  ;
        action= genres["action"] ;
        puzzle =genres["puzzle"]  ;
        strategy= genres["strategy"]  ;
        rpg =genres["rpg"]  ;
        sports= genres["sports"]  ;
        adventure =genres["adventure"]  ;
        racing= genres["racing"]  ;
        card =genres["card"]  ;

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



