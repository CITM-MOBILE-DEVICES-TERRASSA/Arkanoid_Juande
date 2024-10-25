using UnityEngine;

public class BallMovement : MonoBehaviour
{
   
    public new Rigidbody2D rigidbody2D;

    public float speed = 300;

    private Vector2 velocity;

    Vector2 startPosition;

    private void Start()
    {

        startPosition = transform.position;

        ResetBall();

    }


    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("Dead"))
        {

            FindAnyObjectByType<GameManager>().LosseHealth();

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

