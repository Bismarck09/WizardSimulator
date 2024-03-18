using UnityEngine;
using UnityEngine.UI;

public class NewMagicBar : MonoBehaviour
{
    [SerializeField] private Experience _experience;
    [SerializeField] private Slider _slider;

    private void Start()
    {
        _slider.maxValue = _experience.GetMaximumNumberOfExperience();
        _slider.value = Progress.Instance.Experience;
    }

    private void OnEnable()
    {
        _experience.TakedExperience += SetExperience;
        _experience.ResetedExperience += UpdateBar;
    }

    private void OnDisable()
    {
        _experience.TakedExperience -= SetExperience;
        _experience.ResetedExperience -= UpdateBar;
    }

    private void SetExperience(float experience)
    {
        _slider.value = experience;
    }

    private void UpdateBar(float experience, float maxExperience)
    {
        _slider.maxValue = maxExperience;
        _slider.value = experience;
    }
}
