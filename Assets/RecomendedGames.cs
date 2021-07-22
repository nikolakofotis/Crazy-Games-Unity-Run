using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecomendedGames : MonoBehaviour
{
    public User user;
    public PlayGames games;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void RecomendGames()
    {
        foreach(Games game in user.gamesPlayed)
        {
            user.AddGame(game.gameGenre);
        }

        user.GetValues();

        //meta analoga ta paixnidia poy exei paiksei pio poly o xrhsths tha toy vgazei proteinomena paixnidia poy tha ta dialegei apo thn lista paixnidion

    }


}
