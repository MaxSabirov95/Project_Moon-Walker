using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
    public float playerHP;
    public float playerEnergy;
    public float playerOxygen;
    public float playerXp;
    public int playerLevel;

    public float[] playerPosition;

    public GameData(PlayerUI player)
    {
        playerHP = player.playerHP;
        playerEnergy = player.playerEnergy;
        playerOxygen = player.playerOxygen;
        playerXp = player.playerXp;
        playerLevel = player.playerLevel;
        
        playerPosition = new float[2];
        playerPosition[0] = player.transform.position.x;
        playerPosition[1] = player.transform.position.y;
    }

}
