using UnityEngine;

public class StartArena : MonoBehaviour
{
    [SerializeField] private StartBattle _startBattle;
    [SerializeField] private EnableAbility _enableAbility;

    private void OnEnable()
    {
        _startBattle.StartedBattle += EnablePlayerAbility;
    }

    private void OnDisable()
    {
        _startBattle.StartedBattle -= EnablePlayerAbility;
    }

    private void EnablePlayerAbility()
    {
        _enableAbility.EnablePlayerAbility();
    }
}
