using System.Collections.Generic;
using UnityEngine;

public class PowerUpManager : MonoBehaviour
{
    public void ApplyDamageToAllBricks()
    {
        // Encuentra todos los bricks en pantalla y aplica daño a cada uno
        Brick[] allBricks = FindObjectsOfType<Brick>();

        foreach (Brick brick in allBricks)
        {
            brick.LoseLife(1); // Resta una vida a cada brick
        }
    }
}
