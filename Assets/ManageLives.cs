using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class ManageLives : MonoBehaviour
{
    public Text livesText;
    private int startingLives;
    public Button livesButton;
    public User user;
    void Start()
    {
        startingLives = 5;
        livesText.text = user.currentLives + " X";
    }

    // Update is called once per frame
    void Update()
    {
        if(startingLives!=10)
        {
            livesButton.interactable = true;
        }
        else
        {
            livesButton.interactable = false;
        }
    }

    

    public IEnumerator IncreaseLives()
    {



       int newLive= user.currentLives += 1;
            livesText.text =newLive.ToString() + " X";
        WWWForm form = new WWWForm();
        form.AddField("username", user.currentUsername);
        form.AddField("email", user.currentEmail);
        form.AddField("points", user.currentScore);
        form.AddField("lives", newLive);
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
                

            }
        }


    }

}
