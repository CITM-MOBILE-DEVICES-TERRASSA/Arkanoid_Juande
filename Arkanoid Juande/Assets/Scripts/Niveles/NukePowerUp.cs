using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NukePowerUp : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ball")) // Aseg�rate de que la bola tenga el tag "Ball"
        {
            // Encuentra el PowerUpManager y aplica el da�o a todos los bricks
            PowerUpManager powerUpManager = FindObjectOfType<PowerUpManager>();
            if (powerUpManager != null)
            {
                powerUpManager.ApplyDamageToAllBricks();
            }

            Destroy(gameObject); // Destruye el objeto de power-up despu�s de activar el efecto
        }
    }


}
