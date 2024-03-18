using System;
using UnityEngine;

public class ArenaVictory : MonoBehaviour
{
    [SerializeField] private DarkMagicianSpawner _darkMagicianSpawner;

    public event Action ArenaVictoried;

    private void OnEnable()
    {
        _darkMagicianSpawner.DarkMagiciansOver += Victory;
    }

    private void OnDisable()
    {
        _darkMagicianSpawner.DarkMagiciansOver -= Victory;
    }

    private void Victory()
    {
        ArenaVictoried?.Invoke();
    }
}
