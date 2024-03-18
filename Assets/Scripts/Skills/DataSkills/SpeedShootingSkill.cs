using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SpeedShootingSkill : Skill
{
    [SerializeField] private DamageMagicCreator _magicCreator;

    public override TextMeshProUGUI RemainingReloadTimeText { get; set; }
    public override float ReloadTime { get; set; }
    public override float RemainingReloadTime { get; set; }
    public override float TimeElapsed { get; set; }
    public override float WorkTimeOfSkill { get; set; }
    public override bool IsActive { get; set; }
    public override bool IsEnable { get; set; }

    private void Awake()
    {
        ReloadTime = 30;
        WorkTimeOfSkill = 10;
    }

    private void OnEnable()
    {
        IsEnable = false;
        IsActive = false;
        RemainingReloadTime = PlayerPrefs.GetFloat("SpeedShootingSkill");

        RunReloadSkill();
    }

    private void OnDisable()
    {
        PlayerPrefs.SetFloat("SpeedShootingSkill", RemainingReloadTime);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
            EnableSkill();
    }

    public override void WorkOfSkill()
    {
        _magicCreator.StartSpeedShootingSkill(WorkTimeOfSkill);
    }
}
