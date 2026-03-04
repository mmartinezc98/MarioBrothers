using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ScoreManager
{
    public static void AddPoints(int amount)
    {
        Main.Player.PointsChange(amount);
    }

}
