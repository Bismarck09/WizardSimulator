using System;
using System.Runtime.CompilerServices;
using UnityEngine;

public class DarkMagicianHealth : MonoBehaviour, IMagician
{
    [SerializeField] private float _maximumNumberOfLive;

    private DarkMagicianSpawner _darkMagicianSpawner;
    private DarkMagician _darkMagician;

    private float _currentLive;

    public float MaximumNumberOfLive => _maximumNumberOfLive;

    public event Action<float> CausedDamage;
    public event Action DiedDarkMagician;

    private void Start()
    {
        _currentLive = _maximumNumberOfLive;

        _darkMagician = GetComponent<DarkMagician>();
        _darkMagicianSpawner = FindObjectOfType<DarkMagicianSpawner>();
    }

    private void OnEnable()
    {
        CausedDamage += CheckAlive;
        DiedDarkMagician += KillMe;
    }

    private void OnDisable()
    {
        CausedDamage -= CheckAlive;
        DiedDarkMagician -= KillMe;
    }

    public void TakeDamage(float damage)
    {
        _currentLive -= damage;
        CausedDamage?.Invoke(_currentLive);

    }

    public void CheckAlive(float currentLive)
    {
        if(_currentLive <= 0)
            DiedDarkMagician?.Invoke();
    }

    public float GetMaximumNumberOfLives()
    {
        return MaximumNumberOfLive;
    }

    public void KillMe()
    {
        _darkMagicianSpawner.RemoveDarkMagican(_darkMagician);
        _darkMagicianSpawner.CheckNumberOfDarkMagician();
        Destroy(gameObject);
    }
}
