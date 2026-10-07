using UnityEngine;

public class Ball : MonoBehaviour
{
    public float speed = 200f;

    private Rigidbody2D _rigidbody;

    [SerializeField] private AudioManager audioManager;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        ResetPosition();
    }

    private void AddStartingForce()
    {
        float x = Random.value < 0.5f ? -1.0f : 1.0f;

        float y = Random.value < 0.5f
            ? Random.Range(-1.0f, -0.5f)
            : Random.Range(0.5f, 1.0f);

        Vector2 direction = new Vector2(x, y).normalized;

        _rigidbody.AddForce(direction * speed);
    }

    public void AddForce(Vector2 force)
    {
        _rigidbody.AddForce(force);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Paddle hit sound
        if (collision.gameObject.CompareTag("Paddle"))
        {
            if (audioManager != null)
            {
                audioManager.PlayPaddleHitSound();
            }
        }
    }

    public void ResetPosition()
    {
        _rigidbody.position = Vector2.zero;
        _rigidbody.linearVelocity = Vector2.zero;

        AddStartingForce();
    }
}