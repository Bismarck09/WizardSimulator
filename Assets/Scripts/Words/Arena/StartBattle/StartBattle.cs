using System;
using UnityEngine;

public class StartBattle : MonoBehaviour
{
    [SerializeField] private StartTimer _timer;

    public event Action StartedBattle;

    private void OnEnable()
    {
        _timer.TimerOver += StartingBattle;
    }

    private void OnDisable()
    {
        _timer.TimerOver -= StartingBattle;
    }

    private void StartingBattle()
    {
        StartedBattle?.Invoke();
    }
}
