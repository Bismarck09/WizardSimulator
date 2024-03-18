using UnityEngine;

public class PartnerRotation : MonoBehaviour
{
    private PartnerShooting _shooting;

    private void Awake()
    {
        _shooting = GetComponent<PartnerShooting>();
    }

    private void Update()
    {
        if (_shooting.CurrentTarget != null)
            transform.LookAt(_shooting.CurrentTarget.transform);
    }
}
