using UnityEngine;

public class RangeAim : MonoBehaviour
{
    public Transform weapon;
    public float weaponDistance = 0.4f;
    private Vector2 aimDirection = Vector2.up;

    // recieves vector2 storing the direction player is aiming
    public void SetAim(Vector2 direction)
    {
        // stops gun from going to default position when input stops
        if (direction.magnitude > 0.1f)
        {
            aimDirection = direction.normalized;
        }
    }

    void Update()
    {
        // moving weapon.position to correct place around player
        weapon.position = transform.position + ((Vector3)aimDirection * weaponDistance); // cannot add vector2 (aimDirection) to vector3 (transform.position) so converting aimDirection to vector3

        // finding and applying correct angle for weapon
        float angle = Mathf.Atan2(aimDirection.y,aimDirection.x); // x = adjacent, y = opposite - using arctan to find angle - Atan2 lets me do it 360 degrees
        float degreeAngle = angle * Mathf.Rad2Deg; // arctan function returns in radians so have to convert to degrees using Mathf.Rad2Deg
        weapon.rotation = Quaternion.Euler(0f, 0f, degreeAngle - 90); // -90 is temporary since my sprite pointed up originally
    }
}
