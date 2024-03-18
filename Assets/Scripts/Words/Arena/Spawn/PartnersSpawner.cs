using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartnersSpawner : MonoBehaviour
{
    [SerializeField] private PlayerLevel _playerLevel;
    [SerializeField] private PartnersBuy _partnersBuy;
    [SerializeField] private StartSpawn _startSpanwning;
    [SerializeField] private PartnerSpawnIndex[] _PartnersLevels;
    [SerializeField] private Vector3[] _spawnPositions;

    private List<PartnerSpawnIndex> _partners;

    private int _numberOfPartners;

    private void Start()
    {
        _partners = new List<PartnerSpawnIndex>();
    }

    private void OnEnable()
    {
        _startSpanwning.StartedSpawning += SpawnPartner;
        _partnersBuy.BoughtPartner += PartnerBuy;
    }

    private void OnDisable()
    {
        _startSpanwning.StartedSpawning -= SpawnPartner;
        _partnersBuy.BoughtPartner -= PartnerBuy;
    }

    private void PartnerBuy()
    {
        _numberOfPartners++;
    }

    private void SpawnPartner()
    {
        StartCoroutine(SpawnAllPartners());
    }

    private IEnumerator SpawnAllPartners()
    {
        for (int i = 0; i < _numberOfPartners; i++)
        {
            yield return new WaitForSeconds(1);
            AddPartner(_playerLevel.Level, i);

            _partners[i].IndexOfSpawn = i;
        }
    }

    private void AddPartner(int level, int numberSpawn)
    {
        _partners.Add(Instantiate(_PartnersLevels[level], _spawnPositions[numberSpawn], new Quaternion(0, 180, 0, 0)));
    }
}
