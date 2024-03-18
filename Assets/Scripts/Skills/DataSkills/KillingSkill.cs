using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class KillingSkill : Skill
{
    public override TextMeshProUGUI RemainingReloadTimeText { get; set; }
    public override float ReloadTime { get; set; }
    public override float RemainingReloadTime { get; set; }
    public override float TimeElapsed { get; set; }
    public override float WorkTimeOfSkill { get; set; }
    public override bool IsActive { get; set; }
    public override bool IsEnable { get; set; }

    private bool _isTotalHit;

    private void Awake()
    {
        ReloadTime = 40;
        WorkTimeOfSkill = 0.5f;
    }

    private void OnEnable()
    {
        IsEnable = false;
        IsActive = false;

        RemainingReloadTime = PlayerPrefs.GetFloat("KillingSkill");
        RunReloadSkill();
    }

    private void OnDisable()
    {
        PlayerPrefs.SetFloat("killingSkill", RemainingReloadTime);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
            EnableSkill();
    }

    public override void WorkOfSkill()
    {
        _isTotalHit = true;
    }

    public bool GetSkillInfo()
    {
        return _isTotalHit;
    }

    public void SetNormalDamage()
    {
        _isTotalHit = false;
    }
}
