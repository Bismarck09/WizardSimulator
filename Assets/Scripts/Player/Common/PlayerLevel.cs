using JetBrains.Annotations;
using System;
using TMPro;
using UnityEngine;

public class PlayerLevel : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _playerLevelText;

    private ArenaVictory _arenaVictory;

    private int _playerLevel;

    public int Level => _playerLevel;

    public event Action<int> IncreacedPlayerLevel;

    private void Awake()
    {
        _arenaVictory = FindObjectOfType<ArenaVictory>();
    }

    private void Start()
    {
        _playerLevel = Progress.Instance.PlayerLevel;
        _playerLevelText.text = "Уровень " + (_playerLevel + 1);
    }

    private void OnEnable()
    {
        if (_arenaVictory != null)
            _arenaVictory.ArenaVictoried += IncreaseLevel;
    }

    private void OnDisable()
    {
        if (_arenaVictory != null)
            _arenaVictory.ArenaVictoried -= IncreaseLevel;
    }

    private void IncreaseLevel()
    {
        _playerLevel++;

        Progress.Instance.PlayerLevel = _playerLevel;
        _playerLevelText.text = "Уровень " + (_playerLevel + 1);
        IncreacedPlayerLevel?.Invoke(_playerLevel);
    }
}
