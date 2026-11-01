using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour
{

    private Movement moveScript;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        moveScript = GetComponent<Movement>();
    }

    // Called when inputs change - public so Player Input component can find it
    public void OnMove(InputValue value)
    {
        // Gets input Vector2 from Player Input component
        Vector2 inputDirection = value.Get<Vector2>();

        // Sends inputDirection to Movement script
        moveScript.SetMoveDirection(inputDirection);

        // Debug output appearing when moving
        if (inputDirection.magnitude > 0.1f)
        {
            Debug.Log($"X={inputDirection.x:F2}, Y={inputDirection.y:F2}");
        }
    }
}