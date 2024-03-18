using System;
using UnityEngine;

public class StartSpawn : MonoBehaviour
{
    [SerializeField] private GameObject _startGamePanel;

    public event Action StartedSpawning;

    public void StartSpawning()
    {
        StartedSpawning?.Invoke();
        DisableStartGamePanel();
    }

    private void DisableStartGamePanel()
    {
        _startGamePanel.SetActive(false);
    }
}
