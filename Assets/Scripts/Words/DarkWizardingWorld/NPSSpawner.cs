using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPSSpawner : MonoBehaviour
{
    [SerializeField] private NPS[] _npsLevels;
    [SerializeField] private Vector3[] _spawnPositions;

    private List<NPS> _nps;

    private void Start()
    {
        _nps = new List<NPS>();

        SpawnAllNPS();
    }

    private void SpawnAllNPS()
    {
        for (int i = 0; i < _spawnPositions.Length; i++)
        {
            _nps.Add(Instantiate(_npsLevels[Progress.Instance.PlayerLevel], _spawnPositions[i], Quaternion.identity));
        }
    }
}
