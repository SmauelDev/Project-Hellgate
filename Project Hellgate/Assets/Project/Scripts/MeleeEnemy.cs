using UnityEngine;

public class MeleeEnemy : EnemyMain
{

    // Update is called once per frame
    void Update()
    {
        Vector2 moveDirection = (Vector2)player.transform.position - (Vector2)transform.position;
        moveScript.SetMoveDirection(moveDirection.normalized);

    }
}