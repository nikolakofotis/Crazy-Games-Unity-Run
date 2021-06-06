using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckIfOnline : MonoBehaviour
{
    public GameObject container;
    public GameObject[] buttons;
    public string[] names;
    public string contentTag;
    private List<string> onlineNames;

    void Start()
    {
        buttons = GameObject.FindGameObjectsWithTag(contentTag);
        onlineNames = new List<string>();
        GetNames();
        OnlineCheck();
    }

    // Update is called once per frame
    void Update()
    {

    }

    //ypothetika vlepoyme an kapoios einai online h offline kai xrisimopoioyme random gia na to kathorisoyme, se pragmatikes sinthikes tha kaname kati paromoio alla oxi me random alla vlepontas pragmatika an einai online 
    private void  OnlineCheck()
    {
        
        foreach(GameObject g in buttons)
        {
          float f=  Random.value;
            Image b = g.GetComponent<Image>();
            string s;

            if(f<=0.5f)
            {
                b.color = new Color(0.4f, 1, 0.3f);
                s = g.GetComponentInChildren<Text>().text;
                onlineNames.Add(s);
               
            }
            else
            {
                b.color = new Color(1, 0.3f, 0.3f);
            }
        }
    }

    //pairnei ta onomata twn filwn mas mesa apo thn vash, sthn periptosh mas den exoyme vash dedomenon kai tha ta paroyme tyxaia.
    private void GetNames()
    {
        
        for(int i=0;i<buttons.Length;i++)
        {
            Text t = buttons[i].GetComponentInChildren<Text>();
            t.text = names[i];

        }
    }

    public List<string> OnlineFriends()
    {
        return onlineNames;
    }
}
