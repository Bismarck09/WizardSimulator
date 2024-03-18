using UnityEngine;

public class StartMenu : MonoBehaviour
{
    [SerializeField] private EnableAbility _enableAbility;

    private void Start()
    {
        _enableAbility.EnablePlayerAbility();
    }
}
