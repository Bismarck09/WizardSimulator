using DG.Tweening;
using System.Collections.Generic;
using UnityEngine;

public class DarkMagicianMovement : MonoBehaviour
{
    [SerializeField] private Vector3[] _endPositions;

    private StartBattle _startBattle;
    private DarkMagician _darkMagician;
    private float _duration = 2;
    private int _indexOfSpawn;

    private void Awake()
    {
        _startBattle = FindObjectOfType<StartBattle>();
        _darkMagician = GetComponent<DarkMagician>();
    }

    private void OnEnable()
    {
        _startBattle.StartedBattle += Move;
    }

    private void OnDisable()
    {
        _startBattle.StartedBattle -= Move;
    }

    private void Move()
    {
         SetIndexOfSpawn();
         transform.DOMove(_endPositions[_indexOfSpawn], _duration).SetEase(Ease.Linear).SetLoops(-1, LoopType.Yoyo);
    }

    private void SetIndexOfSpawn()
    {
        _indexOfSpawn = _darkMagician.AssignIndexOfSpawn();
    }
}
