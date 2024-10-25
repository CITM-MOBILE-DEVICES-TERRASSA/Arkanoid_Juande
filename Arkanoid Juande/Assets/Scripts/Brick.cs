using UnityEngine;

public class Brick : MonoBehaviour
{
    public int lives = 1; // Vidas del brick

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            LoseLife();
        }
    }

    private void LoseLife()
    {
        lives--; // Reduce una vida

        if (lives <= 0)
        {
            // Obtén la referencia al ParticleManager y crea el efecto
            ParticleManager particleManager = FindObjectOfType<ParticleManager>();
            if (particleManager != null)
            {
                particleManager.CreateBrickDeathParticle(transform.position);
            }

            Destroy(gameObject); // Destruye el brick si no tiene más vidas
        }
    }
}
