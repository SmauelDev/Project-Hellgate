using UnityEngine;

public class Movement : MonoBehaviour
{
    public float moveSpeed = 1f;
    private Rigidbody2D body;
    private Vector2 moveDirection;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    // Given normalised movement direction from either player input or enemy script
    public void SetMoveDirection(Vector2 direction)
    {
        moveDirection = direction;
    }

    // Updates body's velocity in time with physics engine
    void FixedUpdate()
    {
        body.linearVelocity = moveDirection * moveSpeed;
    }
}