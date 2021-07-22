using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Facebook.Unity;
using UnityEngine.UI;

public class SingIn : MonoBehaviour
{

    private void Awake()
    {
        if(!FB.IsInitialized)
        {
            FB.Init(() =>
            {
                if(FB.IsInitialized)
                {
                    FB.ActivateApp();
                }
                else
                {
                    print("Could not open facebook");
                }
            });
        }
    }

    void Start()
    {
        
    }

   
    void Update()
    {
        
    }

    public void LogInWithFB()
    {
        List<string> permissions = new List<string>() {"public_profile","email","user_friends" };
        FB.LogInWithReadPermissions(permissions);
        InviteFriends();
    }

    public void InviteFriends()
    {
        FB.AppRequest("Hey join Crazy Games and get one premium feature for free" , title:"Crazy Games");
    }
}
