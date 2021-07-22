using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Games : MonoBehaviour
{
    public string gameName, gameId, gameGenre;
    
    public  Games(string gameName, string gameId, string gameGenre)
    {
        this.gameGenre = gameGenre;
        this.gameName = gameName;
        this.gameId = gameId;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void  SetGame(string gameName, string gameId,string gameGenre)
    {
        this.gameGenre = gameGenre;
        this.gameName = gameName;
        this.gameId = gameId;
    }
}
