using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageMagicImprovement : MonoBehaviour
{
    [SerializeField] private Experience _playerResources;

    private int _damageMagicLevel;

    public int DamageMagicLevel => _damageMagicLevel;

    private void Start()
    {
        _damageMagicLevel = Progress.Instance.DamageMagicLevel;
    }

    private void OnEnable()
    {
        _playerResources.ImprovedMagic += MagicImprovement;
    }

    private void OnDisable()
    {
        _playerResources.ImprovedMagic -= MagicImprovement;
    }

    private void MagicImprovement()
    {
        _damageMagicLevel++;

        Progress.Instance.DamageMagicLevel = _damageMagicLevel;
    }
}
