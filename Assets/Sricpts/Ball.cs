using UnityEngine;

public class Ball : MonoBehaviour
{
    public float speed = 200f;
    private Rigidbody2D _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        AddStartingForce();
    }

    private void AddStartingForce()
    {
        float x = Random.value < -0.5f ? -1.0f : 1.0f;
        float y = Random.value < 0.5f ?  Random.Range(-1.0f, -0.5f) : 
                                          Random.Range(0.5f, 1.0f);

        Vector2 _direction = new Vector2(x, y);
        _rigidbody.AddForce(_direction * this.speed);
    }

    public void AddForce(Vector2 force)
    {
        _rigidbody.AddForce(force);
    }
}
