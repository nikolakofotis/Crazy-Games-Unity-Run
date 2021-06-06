using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InviteFriends : MonoBehaviour
{
    public GameObject inviteFriends;
    public GameObject mainMenuCanvas;
    void Start()
    {
        
    }

    
    void Update()
    {
        
    }

    public void InviteFriendsOpen()
    {
        inviteFriends.SetActive(true);
    }

    public void BackButton()
    {
        inviteFriends.SetActive(false);
    }

    public void MoveToMain()
    {
        mainMenuCanvas.SetActive(true);
        gameObject.SetActive(false);
    }
}

