using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerDataAutumn
{
    public int totalScoreA;
    public int totalHeartA;
    public int totalFish1A;
    public int totalFish2A;
    public float[] positionA;

    public PlayerDataAutumn(PlayerControlAutumn player)
    {
        totalScoreA = player.totalScoreA;
        totalHeartA = player.totalHeartA;
        totalFish1A = player.totalFish1A;
        totalFish2A = player.totalFish2A;

        positionA = new float[3];
        positionA[0] = player.transform.position.x;
        positionA[1] = player.transform.position.y;
        positionA[2] = player.transform.position.z;
    }
}
