using UnityEngine;

public class BallMovement : MonoBehaviour
{
    public new Rigidbody2D rigidbody2D;
    public float speed = 300;
    private Vector2 velocity;
    Vector2 startPosition;

    // Añade una variable para el AudioSource
    private AudioSource audioSource;

    private void Start()
    {
        startPosition = transform.position;
        audioSource = GetComponent<AudioSource>(); // Obtén el componente AudioSource
        ResetBall();
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

        velocity.x = Random.Range(-1f, 1f);
        velocity.y = 1;

        rigidbody2D.AddForce(velocity * speed);
    }
}
