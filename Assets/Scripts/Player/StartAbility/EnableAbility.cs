using UnityEngine;

public class EnableAbility : MonoBehaviour
{
    [SerializeField] private PlayerShooting _shooting;
    [SerializeField] private PlayerMovement _movement;
    [SerializeField] private PlayerRotation _rotation;

    public void EnablePlayerAbility()
    {
        _shooting.EnableShooting();
        _movement.EnableMoving();
        _rotation.EnableRotation();
    }
}
