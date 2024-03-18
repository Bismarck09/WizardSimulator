using UnityEngine;

public class DarkMagicianRotation : MonoBehaviour
{
    private DarkMagicianShooting _shooting;

    private void Awake()
    {
        _shooting = GetComponent<DarkMagicianShooting>();
    }

    private void Update()
    {
        if (_shooting.CurrentTarget != null)
            transform.LookAt(_shooting.CurrentTarget.transform);
    }
}
