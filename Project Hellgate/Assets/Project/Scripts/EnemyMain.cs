using UnityEngine;

public class EnemyMain : MonoBehaviour
{
    protected Movement moveScript; // protected allows child scripts to see and change this
    protected RangeAim aimScript;
    protected GameObject player;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        moveScript = GetComponent<Movement>();
        aimScript = GetComponent<RangeAim>(); 

        // auto finds player object through PlayerInput script
        global::PlayerInput inputScript = Object.FindAnyObjectByType<global::PlayerInput>();
        player = inputScript.gameObject;
    }

    // health/damage function will go here
}
