using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour
{

    private Movement moveScript;
    private RangeAim aimScript;
    Camera cam;
    private UnityEngine.InputSystem.PlayerInput input;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        moveScript = GetComponent<Movement>();
        aimScript = GetComponent<RangeAim>();
        cam = Camera.main;
        input = GetComponent<UnityEngine.InputSystem.PlayerInput>(); // had to directly call unity's playerinput component since my own script has the same name :/ will not make the same mistake again
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
        // mouse and controller have different vector2 values (mouse - pixel positions, controller - joystick tilt direction)
        Debug.Log("Control scheme rn:" + input.currentControlScheme);
        if (input.currentControlScheme == "Keyboard&Mouse")
        {
            Vector2 cursorPos = value.Get<Vector2>(); 
            Vector3 mousePos = cam.ScreenToWorldPoint(cursorPos); // screentoworldpoint returns vector3
            Vector2 mouseInput = (Vector2)mousePos - (Vector2)transform.position; // so have to convert back to vector2 for setaim
            aimScript.SetAim(mouseInput);
        }
        else if (input.currentControlScheme == "Gamepad")
        {
            Vector2 controllerInput = value.Get<Vector2>();
            aimScript.SetAim(controllerInput);
        }
    }
}