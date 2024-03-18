using System.Collections.Generic;
using UnityEngine;

public class EnableSkills : MonoBehaviour
{
    [SerializeField] private PlayerLevel _playerLevel;
    [SerializeField] private SpeedMovementSkill _speedMovementSkill;
    [SerializeField] private HealingSkill _healingSkill;
    [SerializeField] private KillingSkill _killingSkill;
    [SerializeField] private SpeedShootingSkill _speedShootingSkill;

    private List<Skill> _skills;

    private void Awake()
    {
        _skills = new List<Skill>() { _speedMovementSkill, _healingSkill, _killingSkill, _speedShootingSkill};
    }

    private void OnEnable()
    {
        _playerLevel.IncreacedPlayerLevel += OpenNewSkill;
    }

    private void OnDisable()
    {
        _playerLevel.IncreacedPlayerLevel -= OpenNewSkill;
    }

    private void OpenNewSkill(int playerLevel)
    {
        _skills[playerLevel - 1].IsEnable = true;
    }

    public void EnableSkill()
    {
        for (int i = 1; i <= Progress.Instance.PlayerLevel; i++)
        {
            _skills[i - 1].IsEnable = true;
        }
    }

}
