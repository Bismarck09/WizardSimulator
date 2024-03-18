using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DarkMagicianSpawner : MonoBehaviour
{
    [SerializeField] private StartSpawn _startSpawn;
    [SerializeField] private DarkMagician[] _darkMagicianLevels;
    [SerializeField] private Vector3[] _spawnPositions;

    private List<DarkMagician> _darkMagicians;

    private int _playerLevel;
    private int _maximumPlayerLevel;

    public event Action SpawnedDarkMagicians;
    public event Action DarkMagiciansOver;

    private void Start()
    {
        _playerLevel = Progress.Instance.PlayerLevel;
        _maximumPlayerLevel = Progress.Instance.MaximumPlayerLevel;
        _darkMagicians = new List<DarkMagician>();
    }

    private void OnEnable()
    {
        _startSpawn.StartedSpawning += SpawnDarkMagician;
    }

    private void OnDisable()
    {
        _startSpawn.StartedSpawning -= SpawnDarkMagician;
    }

    private void SpawnDarkMagician()
    {
        StartCoroutine(SpawnAllDarkMagician());
    }

    private IEnumerator SpawnAllDarkMagician()
    {
        for (int i = 0; i < _spawnPositions.Length; i++)
        {
            yield return new WaitForSeconds(1);

            if (i < (_spawnPositions.Length - 2) || _playerLevel + 1 > _maximumPlayerLevel)
                AddDarkMagician(_playerLevel, i);
            else
                AddDarkMagician(_playerLevel + 1, i);

            _darkMagicians[i].IndexOfSpawn = i;
        }

        SpawnedDarkMagicians?.Invoke();
    }

    private void AddDarkMagician(int level, int numberSpawn)
    {
        _darkMagicians.Add(Instantiate(_darkMagicianLevels[level], _spawnPositions[numberSpawn], Quaternion.identity));
    }

    public void RemoveDarkMagican(DarkMagician darkMagician)
    {
        _darkMagicians.Remove(darkMagician);
    }

    public void CheckNumberOfDarkMagician()
    {
        if (_darkMagicians.Count <= 0)
            DarkMagiciansOver?.Invoke();
    }
}
