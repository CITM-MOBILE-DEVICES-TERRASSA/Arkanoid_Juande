using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NukePowerUp : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ball")) // Asegúrate de que la bola tenga el tag "Ball"
        {
            // Encuentra el PowerUpManager y aplica el daño a todos los bricks
            PowerUpManager powerUpManager = FindObjectOfType<PowerUpManager>();
            if (powerUpManager != null)
            {
                powerUpManager.ApplyDamageToAllBricks();
            }

            Destroy(gameObject); // Destruye el objeto de power-up después de activar el efecto
        }
    }


}
