using UnityEngine;

public class DamageMagic : MonoBehaviour
{
    private const string NonInfluentialObjects = "NonInfluentialObjects";

    [SerializeField] private float _damagePower;

    private GameObject _parent;
    private KillingSkill _killingSkill;

    private float _liveTime = 4;
    private bool _isTotalHit;

    private void Start()
    {
        _killingSkill = FindObjectOfType<KillingSkill>();

        _isTotalHit = _killingSkill.GetSkillInfo();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer != LayerMask.NameToLayer(NonInfluentialObjects))
        {
            if (other.gameObject != _parent)
            {
                IMagician magician = other.gameObject.GetComponent<IMagician>();

                if (magician != null)
                    ApplyDamage(magician);
            }
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        _liveTime -= Time.deltaTime;

        if (_liveTime <= 0)
        {
            transform.parent = null;
            Destroy(gameObject);
        }
    }

    private void ApplyDamage(IMagician magican)
    {
        if (!_isTotalHit)
        {
            magican.TakeDamage(_damagePower);
        }
        else
        {
            magican.KillMe();
            _killingSkill.SetNormalDamage();
        }
    }

    public void SetParent(GameObject parent)
    {
        _parent = parent;
    }
}
