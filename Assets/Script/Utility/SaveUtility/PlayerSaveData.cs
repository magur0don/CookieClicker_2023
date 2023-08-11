using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSaveData
{
    public string PlayerUserName;
    public int PlayerScore;
    public PlayerSaveData(string playerUserName, int playerScore)
    {
        this.PlayerUserName = playerUserName;
        this.PlayerScore = playerScore;
    }
}
