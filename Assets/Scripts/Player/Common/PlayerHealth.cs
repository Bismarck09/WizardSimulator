using System;
using UnityEngine;

public class PlayerHealth : MonoBehaviour, IMagician
{
    [SerializeField] private float[] _numberOfLivesOnLevel;
    [SerializeField] private HealingSkill _healingSkill;

    private float _currentLives;
    private int _playerLevel;

    public float MaximumNumberOfLive => _numberOfLivesOnLevel[_playerLevel];

    public event Action<float> CausedDamage;
    public event Action DiedPlayer;

    private void Start()
    {
        _playerLevel = Progress.Instance.PlayerLevel;
        _currentLives = MaximumNumberOfLive;
    }

    private void OnEnable()
    {
        CausedDamage += CheckAlive;
        _healingSkill.EnabledHealingSkill += HealLives;
    }

    private void OnDisable()
    {
        CausedDamage -= CheckAlive;
        _healingSkill.EnabledHealingSkill -= HealLives;
    }

    private void UpdateLevel(int playerLevel)
    {
        _playerLevel = playerLevel;
    }

    private void HealLives()
    {
        _currentLives += (MaximumNumberOfLive / 100) * 40;
        CausedDamage?.Invoke(_currentLives);
    }

    public void TakeDamage(float damage)
    {
        _currentLives -= damage;
        CausedDamage?.Invoke(_currentLives);
    }

    public void CheckAlive(float currentLives)
    {
        if (currentLives <= 0)
        {
           DiedPlayer?.Invoke();
        }
            
    }

    public float GetMaximumNumberOfLives()
    {
        return _numberOfLivesOnLevel[Progress.Instance.PlayerLevel];
    }

    public void KillMe()
    {

    }
}
