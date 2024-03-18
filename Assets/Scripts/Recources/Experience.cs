using System;
using UnityEngine;

public class Experience : MonoBehaviour
{
    [SerializeField] private float[] _numberOfExperienceForNewMagic;
    [SerializeField] private DamageMagicImprovement _damageMagicImprovement;

    private int _numberOfExperience;

    public event Action ImprovedMagic;
    public event Action<float> TakedExperience;
    public event Action<float, float> ResetedExperience;

    private void Start()
    {
        _numberOfExperience = Progress.Instance.Experience;
    }

    private void OnEnable()
    {
        TakedExperience += CheckExperience;
    }

    private void OnDisable()
    {
        TakedExperience -= CheckExperience;
    }

    public void TakeExperience(int experience)
    {
        _numberOfExperience += experience;

        Progress.Instance.Experience = _numberOfExperience;
        TakedExperience?.Invoke(_numberOfExperience);
    }

    private void CheckExperience(float numberOfExperience)
    {
        if (_numberOfExperienceForNewMagic[_damageMagicImprovement.DamageMagicLevel] <= numberOfExperience)
        {
            ImprovedMagic?.Invoke();
            ResetExperience();
        }
    }

    private void ResetExperience()
    {
        _numberOfExperience = 0;
        Progress.Instance.Experience = _numberOfExperience;

        ResetedExperience?.Invoke(_numberOfExperience, _numberOfExperienceForNewMagic[_damageMagicImprovement.DamageMagicLevel]);
    }

    public float GetMaximumNumberOfExperience()
    {
        return _numberOfExperienceForNewMagic[Progress.Instance.DamageMagicLevel];
    }
}
