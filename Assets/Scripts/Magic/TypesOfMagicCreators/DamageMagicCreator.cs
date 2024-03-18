using System;
using System.Collections;
using UnityEngine;

public class DamageMagicCreator : MonoBehaviour
{
    [SerializeField] private DamageMagic[] _magicLevels;
    [SerializeField] private Animator _animator;

    private float _flightSpeed = 35;
    private float _reloadTime = 1;
    private float _animationTime = 0.9f;
    
    public void TryMagicCreate(Vector3 target, ref float elapsedTimeAfterShooting, GameObject parent, Action EnableSound, Action EnableAnimation, int magicLevel)
    {
        if (elapsedTimeAfterShooting >= _reloadTime)
        {
            elapsedTimeAfterShooting = 0;
            Init(target, parent, EnableSound, magicLevel);
            EnableAnimation();
        }
    }

    private void Init(Vector3 target, GameObject parent, Action spawned, int magicLevel)
    {
        StartCoroutine(DelayedShooting(_animationTime, target, parent, spawned, magicLevel));
    }

    private void ShootMagic(DamageMagic magic ,Vector3 target)
    {
        magic.transform.LookAt(target, Vector3.up);

        Vector3 localForce = new Vector3(0, 0, _flightSpeed);
        Vector3 globalForce = magic.transform.TransformDirection(localForce);

        magic.GetComponent<Rigidbody>().velocity = globalForce;
    }

    private IEnumerator DelayedShooting(float delay, Vector3 target, GameObject parent, Action spawned, int magicLevel)
    {
        yield return new WaitForSeconds(delay);

        DamageMagic magic = Instantiate(_magicLevels[magicLevel], transform.position, Quaternion.identity);
        magic.SetParent(parent);

        spawned?.Invoke();
        ShootMagic(magic,target);
    }

    private IEnumerator EnableSpeedShootingSkill(float workTime)
    {
        _reloadTime /= 2;
        _animationTime /= 2;
        _animator.SetFloat("ShootingSpeed", 2f);

        yield return new WaitForSeconds(workTime);
        _reloadTime *= 2;
        _animationTime *= 2;
        _animator.SetFloat("ShootingSpeed", 1);
    }

    public void StartSpeedShootingSkill(float workTime)
    {
        StartCoroutine(EnableSpeedShootingSkill(workTime));
    }
}
