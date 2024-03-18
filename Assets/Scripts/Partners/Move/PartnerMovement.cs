using DG.Tweening;
using UnityEngine;

public class PartnerMovement : MonoBehaviour
{
    [SerializeField] private Vector3[] _endPositions;

    private StartBattle _startBattle;
    private PartnerSpawnIndex _partner;
    private float _duration = 2;
    private int _indexOfSpawn;

    private void Awake()
    {
        _startBattle = FindObjectOfType<StartBattle>();
        _partner = GetComponent<PartnerSpawnIndex>();
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
        _indexOfSpawn = _partner.AssignIndexOfSpawn();
    }
}
