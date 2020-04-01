using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public int totalScore;
    public int totalHeart;
    public int totalFish1;
    public int totalFish2;
    public float[] position;

    public PlayerData (PlayerControl player)
    {
        totalScore = player.totalScore;
        totalHeart = player.totalHeart;
        totalFish1 = player.totalFish1;
        totalFish2 = player.totalFish2;

        position = new float[3];
        position[0] = player.transform.position.x;
        position[1] = player.transform.position.y;
        position[2] = player.transform.position.z;
    }
}
