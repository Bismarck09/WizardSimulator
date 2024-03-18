using System;
using TMPro;
using UnityEngine;

public class HealingSkill : Skill
{
    public override TextMeshProUGUI RemainingReloadTimeText { get; set; }
    public override float ReloadTime { get; set; }
    public override float RemainingReloadTime { get; set; }
    public override float TimeElapsed { get; set; }
    public override float WorkTimeOfSkill { get; set; }
    public override bool IsActive { get; set; }
    public override bool IsEnable { get; set; }

    public event Action EnabledHealingSkill;

    private void Awake()
    {
        ReloadTime = 30;
        WorkTimeOfSkill = 0.5f;
    }

    private void OnEnable()
    {
        IsEnable = false;
        IsActive = false;

        RemainingReloadTime = PlayerPrefs.GetFloat("HealingSkill");
        RunReloadSkill();
    }

    private void OnDisable()
    {
        PlayerPrefs.SetFloat("HealingSkill", RemainingReloadTime);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
            EnableSkill();
    }

    public override void WorkOfSkill()
    {
        EnabledHealingSkill?.Invoke();
    }
}
