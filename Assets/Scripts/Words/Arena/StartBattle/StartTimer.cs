using System;
using System.Collections;
using TMPro;
using UnityEngine;

public class StartTimer : MonoBehaviour
{
    [SerializeField] private float _timerTime;

    private DarkMagicianSpawner _darkMagicianSpawner;
    private float _time;

    public event Action TimerOver;

    private void Awake()
    {
        _darkMagicianSpawner = GetComponent<DarkMagicianSpawner>();
        _time = _timerTime;
    }

    private void OnEnable()
    {
        _darkMagicianSpawner.SpawnedDarkMagicians += StartTime;
    }

    private void OnDisable()
    {
        _darkMagicianSpawner.SpawnedDarkMagicians -= StartTime;
    }

    private void StartTime()
    {
        StartCoroutine(CountingDownTime());
    }

    private IEnumerator CountingDownTime()
    {
        while (_time > 0)
        {
            yield return new WaitForSeconds(0.1f);
            _time -= 0.1f;
        }

        TimerOver?.Invoke();
    }
}
