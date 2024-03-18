using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    [SerializeField] private Gradient _gradient;
    [SerializeField] private Image _fill;

    private IMagician _magician;

    private void Awake()
    {
        _magician = GetComponent<IMagician>();
        _fill.color = _gradient.Evaluate(1f);
    }

    private void Start()
    {
        _slider.maxValue = _magician.GetMaximumNumberOfLives();
        _slider.value = _magician.GetMaximumNumberOfLives();
    }

    private void OnEnable()
    {
        _magician.CausedDamage += SetHealth;
        _magician.CausedDamage += SetFillColor;
    }

    private void OnDisable()
    {
        _magician.CausedDamage -= SetHealth;
        _magician.CausedDamage -= SetFillColor;
    }

    private void SetHealth(float health)
    {
        _slider.value = health;
    }

    private void UpdateBar(float health, float maxHealth)
    {
        _slider.maxValue = maxHealth;
        _slider.value = health;
    }

    private void SetFillColor(float health)
    {
        _fill.color = _gradient.Evaluate(_slider.normalizedValue);
    }
}
