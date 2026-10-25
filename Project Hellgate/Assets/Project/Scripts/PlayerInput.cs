using UnityEngine;

public class PlayerInput : MonoBehaviour
{

    private Movement moveScript;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        moveScript = GetComponent<Movement>();
    }

    // Update is called once per frame
    void Update()
    {
        float xInput = Input.GetAxisRaw("Horizontal");
        float yInput = Input.GetAxisRaw("Vertical");
        Vector2 inputDirection = new Vector2(xInput, yInput).normalized;

        // sends inputDirection vector to movement script
        moveScript.SetMoveDirection(inputDirection);
    }
}
