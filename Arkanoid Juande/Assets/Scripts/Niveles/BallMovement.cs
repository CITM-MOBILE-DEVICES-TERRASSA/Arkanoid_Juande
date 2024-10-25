using UnityEngine;

public class BallMovement : MonoBehaviour
{
    public new Rigidbody2D rigidbody2D;
    public float speed = 300;
    private Vector2 velocity;
    Vector2 startPosition;

    // Añade una variable para el AudioSource
    private AudioSource audioSource;

    private bool isLaunched = false; // Variable para verificar si la bola ha sido lanzada

    private void Start()
    {
        startPosition = transform.position;
        audioSource = GetComponent<AudioSource>(); // Obtén el componente AudioSource
        ResetBall();
    }

    private void Update()
    {
        // Comprueba si se presiona la tecla SPACE y si la bola no ha sido lanzada
        if (Input.GetKeyDown(KeyCode.Space) && !isLaunched)
        {
            LaunchBall(); // Lanza la bola
        }

        if (!isLaunched)
        {
            FollowPlatform(); // Mantén la bola en la plataforma mientras no ha sido lanzada
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Reproduce el sonido al chocar
        if (audioSource != null)
        {
            audioSource.Play(); // Reproduce el sonido
        }

        if (collision.gameObject.CompareTag("Dead"))
        {
            FindAnyObjectByType<GameManager>().LoseHealth();
        }
    }

    public void ResetBall()
    {
        transform.position = startPosition;
        rigidbody2D.velocity = Vector2.zero;
        isLaunched = false; // Resetea la variable de lanzamiento
    }

    private void LaunchBall()
    {
        velocity.x = Random.Range(-1f, 1f);
        velocity.y = 1;

        rigidbody2D.AddForce(velocity.normalized * speed); // Lanza la bola
        isLaunched = true; // Marca que la bola ha sido lanzada
    }

    private void FollowPlatform()
    {
        // Mantiene la posición de la bola en la plataforma
        float platformX = FindObjectOfType<SliderMovement>().transform.position.x; // Obtiene la posición X de la plataforma
        transform.position = new Vector2(platformX, transform.position.y); // Establece la posición de la bola
    }
}
