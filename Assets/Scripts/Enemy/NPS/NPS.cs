using System;
using UnityEngine;

public class NPS : MonoBehaviour, IMagician
{
    [SerializeField] private float _maximumNumberOfLife;
    [SerializeField] private int _numberOfExperience;
    [SerializeField] private int _numberOfCoins;

    private Experience _experince;
    private Coins _coins;
    private NPSRespawn _respawn;
    private float _currentLives;

    public float MaximumNumberOfLive => _maximumNumberOfLife;

    public event Action DiedNPS;
    public event Action<float> CausedDamage;

    private void Awake()
    {
        _experince = FindObjectOfType<Experience>();
        _coins = FindObjectOfType<Coins>();
        _respawn = FindObjectOfType<NPSRespawn>();

        _currentLives = _maximumNumberOfLife;
    }

    private void OnEnable()
    {
        DiedNPS += TakeExperience;
        DiedNPS += TakeCoins;
        DiedNPS += Respawn;
        DiedNPS += KillMe;
        CausedDamage += CheckAlive;
    }

    private void OnDisable()
    {
        DiedNPS -= TakeExperience;
        DiedNPS -= TakeCoins;
        DiedNPS -= Respawn;
        DiedNPS -= KillMe;
        CausedDamage -= CheckAlive;
    }

    public void CheckAlive(float currentLives)
    {
        if (currentLives <= 0)
            DiedNPS?.Invoke();
    }

    public void TakeDamage(float damage)
    {
        _currentLives -= damage;
        CausedDamage?.Invoke(_currentLives);
    }

    public void KillMe()
    {
        gameObject.SetActive(false);
    }

    private void TakeExperience()
    {
        _experince.TakeExperience(_numberOfExperience);
    }

    private void TakeCoins()
    {
        _coins.TakeCoins(_numberOfCoins);
    }

    private void Respawn()
    {
        _respawn.RespawnNPS(this, RecoverLives);
    }

    private void RecoverLives()
    {
        _currentLives = _maximumNumberOfLife;
        CausedDamage?.Invoke(_currentLives);
    }

    public float GetMaximumNumberOfLives()
    {
        return MaximumNumberOfLive;
    }
}
