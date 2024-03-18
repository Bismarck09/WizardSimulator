using System;
using UnityEngine;

public class PartnerHealth : MonoBehaviour, IMagician
{
    [SerializeField] private float _maximumNumberOfLive;

    private float _currentLive;

    public float MaximumNumberOfLive => _maximumNumberOfLive;

    public event Action<float> CausedDamage;
    public event Action DiedPartner;

    private void Start()
    {
        _currentLive = _maximumNumberOfLive;
    }

    private void OnEnable()
    {
        CausedDamage += CheckAlive;
        DiedPartner += KillMe;
    }

    private void OnDisable()
    {
        CausedDamage -= CheckAlive;
        DiedPartner -= KillMe;
    }

    public void TakeDamage(float damage)
    {
        _currentLive -= damage;
        CausedDamage?.Invoke(_currentLive);

    }

    public void CheckAlive(float currentLive)
    {
        if (_currentLive <= 0)
            DiedPartner?.Invoke();
    }

    public float GetMaximumNumberOfLives()
    {
        return MaximumNumberOfLive;
    }

    public void KillMe()
    {
        Destroy(gameObject);
    }
}
