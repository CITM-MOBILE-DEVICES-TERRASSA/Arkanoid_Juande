using UnityEngine;

public class Brick : MonoBehaviour
{
    public int lives = 1; // Vidas del brick

    // A�ade una variable para el AudioSource
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>(); // Obt�n el componente AudioSource
    }

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
            // Obt�n la referencia al ParticleManager y crea el efecto
            ParticleManager particleManager = FindObjectOfType<ParticleManager>();
            if (particleManager != null)
            {
                particleManager.CreateBrickDeathParticle(transform.position);
            }

            // Obt�n la referencia al GameAudioManager y reproduce el sonido
            GameAudioManager audioManager = FindObjectOfType<GameAudioManager>();
            if (audioManager != null)
            {
                audioManager.PlayBrickBreakSound(); // Llama al m�todo para reproducir el sonido
            }

            Destroy(gameObject); // Destruye el brick si no tiene m�s vidas
        }
    }
}
