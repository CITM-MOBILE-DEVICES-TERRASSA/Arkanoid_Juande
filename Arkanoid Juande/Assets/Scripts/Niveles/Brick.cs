using UnityEngine;

public class Brick : MonoBehaviour
{
    public int lives = 3; // Máximo de vidas del brick (ajustable según tus necesidades)
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
        audioSource = GetComponent<AudioSource>(); // Obtén el componente AudioSource
        spriteRenderer = GetComponent<SpriteRenderer>(); // Obtén el componente SpriteRenderer
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
        // Obtén la referencia al ParticleManager y crea el efecto de golpe
        ParticleManager particleManager = FindObjectOfType<ParticleManager>();
        if (particleManager != null)
        {
            particleManager.CreateHitParticle(transform.position); // Crea el efecto de golpe
        }

        LoseLife(1);
    }

    public void LoseLife(int damage)
    {
        lives -= damage; // Reduce una vida
        Debug.Log($"Vidas restantes: {lives}"); // Para depuración

        if (lives > 0)
        {
            UpdateColor(); // Actualiza el color según las vidas restantes
        }
        else
        {
            HandleBrickDestruction();
        }
    }

    private void HandleBrickDestruction()
    {
        // Obtén la referencia al ParticleManager y crea el efecto de muerte
        ParticleManager particleManager = FindObjectOfType<ParticleManager>();
        if (particleManager != null)
        {
            particleManager.CreateBrickDeathParticle(transform.position);
        }

        // Obtén la referencia al GameAudioManager y reproduce el sonido
        GameAudioManager audioManager = FindObjectOfType<GameAudioManager>();
        if (audioManager != null)
        {
            audioManager.PlayBrickBreakSound(); // Llama al método para reproducir el sonido
        }

        // Obtén la referencia al BrickCounter y llama al método BrickDestroyed
        BrickCounter brickCounter = FindObjectOfType<BrickCounter>();
        if (brickCounter != null)
        {
            brickCounter.BrickDestroyed(); // Notifica que un brick ha sido destruido
        }

        // Añadir puntos al destruir un brick
        GameManager gameManager = FindObjectOfType<GameManager>();
        if (gameManager != null)
        {
            gameManager.GainPoints(1); // Suma 1 punto
        }

        Destroy(gameObject); // Destruye el brick si no tiene más vidas
    }

    private void UpdateColor()
    {
        int colorIndex = lives - 1; // Obtener el índice del color basado en las vidas restantes

        if (IsColorIndexValid(colorIndex)) // Verifica que haya un color asignado
        {
            spriteRenderer.color = colors[colorIndex]; // Cambia el color según las vidas restantes
            //Debug.Log($"Color actualizado a: {spriteRenderer.color} con {lives} vidas restantes");
        }
        else
        {
            //Debug.LogWarning($"Índice de color inválido: {colorIndex} para {lives} vidas restantes.");
        }
    }

    private bool IsColorIndexValid(int index)
    {
        return index >= 0 && index < colors.Length; // Verifica que el índice esté dentro de los límites del array
    }
}
