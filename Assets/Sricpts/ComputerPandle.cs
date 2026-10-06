
using UnityEngine;

public class ComputerPaddle : Paddle
{
    public Rigidbody2D ball;

    private void FixedUpdate()
    {
        if (this.ball.position.y > this.transform.position.y)
        {
            _rigidbody.AddForce(Vector2.up * this.speed);
        }
        else if (this.ball.position.y < this.transform.position.y)
        {
            _rigidbody.AddForce(Vector2.down * this.speed);
        }
    }
}