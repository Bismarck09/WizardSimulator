using System.Collections;
using UnityEngine;

public class NPSShooting : MonoBehaviour
{
    [SerializeField] private DamageMagicCreator _damageMagicCreator;
    [SerializeField] private ReactionShoot _reactionShoot;
    [SerializeField] private int _magicLevel;

    private NPS _nps;
    private Player _player;
    private Vector3 _targetPosition;

    private float elapsedTimeAfterShooting = 1;
    private bool _isShooting;

    private void Awake()
    {
        _isShooting = false;

        _nps = GetComponent<NPS>();
        _player = FindObjectOfType<Player>();
    }

    private void OnEnable()
    {
        _nps.DiedNPS += FinishAttack;
    }

    private void OnDisable()
    {
        _nps.DiedNPS -= FinishAttack;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out DamageMagic magic) && !_isShooting && _nps.gameObject.activeSelf)
        {
            _isShooting = true;
            StartCoroutine("Shooting");
        }
    }

    private void Update()
    {
        transform.LookAt(_player.transform.position, Vector3.up);
    }

    private IEnumerator Shooting()
    {
        while (true)
        {
            _targetPosition = new Vector3(_player.transform.position.x, _player.transform.position.y + 1, _player.transform.position.z);

            _damageMagicCreator.TryMagicCreate(_targetPosition, ref elapsedTimeAfterShooting, gameObject, _reactionShoot.EnableSound, _reactionShoot.EnableAnimation, _magicLevel);

            elapsedTimeAfterShooting = 1;
            yield return new WaitForSeconds(elapsedTimeAfterShooting);
        }
    }

    private void FinishAttack()
    {
        _isShooting = false;
    }
}
