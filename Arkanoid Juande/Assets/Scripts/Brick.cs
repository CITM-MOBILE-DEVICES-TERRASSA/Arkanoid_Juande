using UnityEngine;

public class Brick : MonoBehaviour
{
    public int lives = 3; // M�ximo de vidas del brick (ajustable seg�n tus necesidades)
    public Color[] colors; // Array de colores para diferentes vidas
    private AudioSource audioSource;
    private SpriteRenderer spriteRenderer; // Para cambiar el color del sprite

    private void Start()
    {
        InitializeComponents();
        UpdateColor(); // Establece el color inicial
    }

    private void InitializeComponents()
    {
        audioSource = GetComponent<AudioSource>(); // Obt�n el componente AudioSource
        spriteRenderer = GetComponent<SpriteRenderer>(); // Obt�n el componente SpriteRenderer
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            HandleCollision();
        }
    }

    private void HandleCollision()
    {
        LoseLife();
    }

    private void LoseLife()
    {
        lives--; // Reduce una vida
        Debug.Log($"Vidas restantes: {lives}"); // Para depuraci�n

        if (lives > 0)
        {
            UpdateColor(); // Actualiza el color seg�n las vidas restantes
        }
        else
        {
            HandleBrickDestruction();
        }
    }

    private void HandleBrickDestruction()
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

    private void UpdateColor()
    {
        int colorIndex = lives - 1; // Obtener el �ndice del color basado en las vidas restantes

        if (IsColorIndexValid(colorIndex)) // Verifica que haya un color asignado
        {
            spriteRenderer.color = colors[colorIndex]; // Cambia el color seg�n las vidas restantes
            Debug.Log($"Color actualizado a: {spriteRenderer.color} con {lives} vidas restantes");
        }
        else
        {
            Debug.LogWarning($"�ndice de color inv�lido: {colorIndex} para {lives} vidas restantes.");
        }
    }

    private bool IsColorIndexValid(int index)
    {
        return index >= 0 && index < colors.Length; // Verifica que el �ndice est� dentro de los l�mites del array
    }
}
