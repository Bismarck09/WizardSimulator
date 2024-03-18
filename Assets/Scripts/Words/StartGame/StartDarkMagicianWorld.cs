using UnityEngine;

public class StartDarkMagicianWorld : MonoBehaviour
{
    [SerializeField] private EnableAbility _enableAbility;

    private void Start()
    {
        _enableAbility.EnablePlayerAbility();
    }
}
