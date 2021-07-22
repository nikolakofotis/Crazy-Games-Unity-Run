using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using System.Net;

public class PlayGames : MonoBehaviour
{
   
    public User user;
    public Dictionary<string, Games> game = new Dictionary<string, Games>();
    public RecomendedGames reconGames;


    void Awake()
    {
        StartCoroutine(FetchGames("http://localhost/UnityServer/FetchGames.php"));
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void Play()
    {
        for(int x=1; x<=30;x++)
        {
            int random = Random.Range(1, 101);
            if (game.ContainsKey(random.ToString()))
            {
                user.gamesPlayed.Add(game[random.ToString()]);
                
            }
        }

        reconGames.RecomendGames();

    }

    

    public IEnumerator FetchGames(string uri)
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get(uri))
        {
            // Request and wait for the desired page.
            yield return webRequest.SendWebRequest();

            string[] pages = uri.Split('/');
            int page = pages.Length - 1;

            switch (webRequest.result)
            {
                case UnityWebRequest.Result.ConnectionError:
                case UnityWebRequest.Result.DataProcessingError:
                    Debug.LogError(pages[page] + ": Error: " + webRequest.error);
                    break;
                case UnityWebRequest.Result.ProtocolError:
                    Debug.LogError(pages[page] + ": HTTP Error: " + webRequest.error);
                    break;
                case UnityWebRequest.Result.Success:
                    FirstSplit(webRequest.downloadHandler.text);

                    break;
            }
        }
    }


    private void FirstSplit(string s)
    {
        string[] newSplit =s.Split('!');
        SecondSplit(newSplit);
        
    }

    private void SecondSplit(string[] s)
    {
        string[] temp;
        
        foreach(string str in s)
        {
            
            temp = str.Split('/');
            if (temp[0] != "" && temp[1] != "" && temp[2] != "")
            {
                var gamex = new Games(temp[2], temp[1], temp[0]);
                
                game.Add(gamex.gameId, gamex);
                
               
            }
        }

        

        Play();
    }
}

    


