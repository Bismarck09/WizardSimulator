using UnityEngine;

public class FreeTarget : MonoBehaviour
{
    private bool _isAvailable;

    public bool IsAvailable => _isAvailable;

    private void Start()
    {
        _isAvailable = false;
    }

    public void OccupyTarget()
    {
        _isAvailable = true;
    }

    public void UnlockedTarget()
    {
        _isAvailable = false;
    }
}
