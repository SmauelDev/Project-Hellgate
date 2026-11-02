using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour
{

    private Movement moveScript;
    private RangeAim aimScript;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        moveScript = GetComponent<Movement>();
        aimScript = GetComponent<RangeAim>();
    }

    // Called when movement inputs change - public so Player Input component can find it
    public void OnMove(InputValue value)
    {
        // Gets input Vector2 from Player Input component
        Vector2 moveInput = value.Get<Vector2>();

        // Sends inputDirection to Movement script
        moveScript.SetMoveDirection(moveInput);

        // Debug output appearing when moving
        if (moveInput.magnitude > 0.1f)
        {
            Debug.Log($"X={moveInput.x:F2}, Y={moveInput.y:F2}");
        }
    }

    // Called when aim inputs change
    public void OnAim(InputValue value)
    {
        Vector2 aimInput = value.Get<Vector2>();
        
        aimScript.SetAim(aimInput);

    }
}