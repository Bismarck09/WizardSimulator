using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DarkMagicianShooting : MonoBehaviour
{
    private const string _layerName = "DarkMagician";

    [SerializeField] private DamageMagicCreator _damageMagicCreator;
    [SerializeField] private StartBattle _startBattle;
    [SerializeField] private ReactionShoot _reactionShoot;
    [SerializeField] private int _magicLevel;
    [SerializeField] private float _searchRadius;

    private Collider _currentTarget;
    private FreeTarget freeTarget;
    private IMagician magician;

    private float elapsedTimeAfterShooting = 1;
    private bool _isShooting = false;
    private bool _isStartAttack;

    public Collider CurrentTarget => _currentTarget;

    private void Awake()
    {
        _startBattle = FindObjectOfType<StartBattle>();
    }

    private void OnEnable()
    {
        _startBattle.StartedBattle += StartAttack;
    }

    private void OnDisable()
    {
        _startBattle.StartedBattle -= StartAttack;
    }

    private void Update()
    {
        if (_isStartAttack && !_isShooting)
        {
            if (_currentTarget != null)
                StartCoroutine("Shooting");
            else
                FindOpenTarget();
        }
    }

    private IEnumerator Shooting()
    {
        _isShooting = true;

        while (_currentTarget != null)
        {
            Vector3 _targetPosition = new Vector3(_currentTarget.transform.position.x, _currentTarget.transform.position.y + 1, _currentTarget.transform.position.z);

            _damageMagicCreator.TryMagicCreate(_targetPosition, ref elapsedTimeAfterShooting, gameObject, _reactionShoot.EnableSound, _reactionShoot.EnableAnimation, _magicLevel);

            elapsedTimeAfterShooting = 1;
            yield return new WaitForSeconds(elapsedTimeAfterShooting);
        }

        _isShooting = false;
    }

    private void FindOpenTarget()
    {
        Collider[] hits = Physics.OverlapSphere(transform.position, _searchRadius);

        foreach (var hit in FindTargets(hits))
        {
            freeTarget = hit.GetComponent<FreeTarget>();

            if (!freeTarget.IsAvailable)
            {
                freeTarget.OccupyTarget();
                _currentTarget = hit;
                return;
            }
        }

        UnlockedAllTarget(hits);
    }

    private List<Collider> FindTargets(Collider[] hits)
    {
        List<Collider> foundTargets = new List<Collider>();

        foreach (var hit in hits)
        {
            if (hit.TryGetComponent(out magician) && hit.gameObject.layer != LayerMask.NameToLayer(_layerName))
            {
                freeTarget = hit.GetComponent<FreeTarget>();

                if (freeTarget != null)
                    foundTargets.Add(hit);
            }
        }

        return foundTargets;
    }

    private void UnlockedAllTarget(Collider[] hits)
    {
        foreach (var hit in FindTargets(hits))
        {
            freeTarget = hit.GetComponent<FreeTarget>();
            freeTarget.UnlockedTarget();
        }
    }

    private void StartAttack()
    {
        _isStartAttack = true;
    }
}
