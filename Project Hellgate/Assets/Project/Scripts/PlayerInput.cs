using UnityEngine;

public class PlayerInput : MonoBehaviour
{

    private Movement moveScript;
    public float movementDeadzone = 0.2f;

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
        Vector2 inputDirection = new Vector2(xInput, yInput);

        // sends inputDirection vector to movement script
        if (inputDirection.magnitude < movementDeadzone)
        {
            inputDirection = Vector2.zero;
        }

        else {
            inputDirection.Normalize();
        }
        moveScript.SetMoveDirection(inputDirection);


        // total debug shiiiii
        if (Mathf.Abs(xInput) > 0.1f || Mathf.Abs(yInput) > 0.1f)
        {
            Debug.Log($"X={xInput:F2}, Y={yInput:F2}");
        }
    }
}
