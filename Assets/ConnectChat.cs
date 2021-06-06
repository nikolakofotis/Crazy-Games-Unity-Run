using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConnectChat : MonoBehaviour
{
    public CheckIfOnline onlineCheck;
    public List<string> onlineFriends;
    public Text chatText;
    public GameObject onlineFriend;
    IEnumerator Start()
    {
        // onlineFriends = new List<string>();
        yield return new WaitForSeconds(0.1f);
        GetOnlineFriends();
    }


    private void GetOnlineFriends()
    {
        onlineFriends = onlineCheck.OnlineFriends();
    }

    public void ChatWithFriends(GameObject b)
    {
        string name = b.GetComponentInChildren<Text>().text;

        
        if(onlineFriends.IndexOf(name)!=-1)
        {
            chatText.text = "Ο χρήστης " + name + " είναι διαθέσιμος για συνομιλία.";
            onlineFriend.SetActive(true);
        }
        else
        {
            chatText.text = "Ο χρήστης " + name + " δεν είναι συνδεδεμένος αυτήν την στιγμή.";
            onlineFriend.SetActive(false);
        }

       
       
    }
}
