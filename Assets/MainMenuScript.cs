using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuScript : MonoBehaviour
{
    public Canvas[] screens;
    
    void Start()
    {
        
    }

   
    void Update()
    {
        
    }

    public void OpenGames()
    {
        screens[0].gameObject.SetActive(false);
        screens[1].gameObject.SetActive(true);
    }

    public void OpenScreens(int screenNumber)
    {
        for(int i=0;i<screens.Length;i++)
        {
            if(i==screenNumber)
            {
                screens[i].gameObject.SetActive(true);
            }
            else
            {
                screens[i].gameObject.SetActive(false);
            }
        }
    }

    

    

   
}
