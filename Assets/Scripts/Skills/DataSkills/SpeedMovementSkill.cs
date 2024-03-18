using TMPro;
using UnityEngine;

public class SpeedMovementSkill : Skill
{
    [SerializeField] private PlayerMovement _playerMovement;
    [SerializeField] private TextMeshProUGUI _remainingReloadTimeText;

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
        RemainingReloadTimeText = _remainingReloadTimeText;
    }

    private void OnEnable()
    {
        IsEnable = false;
        IsActive = false;
        RemainingReloadTime = PlayerPrefs.GetFloat("SpeedMovementSkill");

        RunReloadSkill();
    }

    private void OnDisable()
    {
        PlayerPrefs.SetFloat("SpeedMovementSkill", RemainingReloadTime);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
            EnableSkill();
    }

    public override void WorkOfSkill()
    {
        _playerMovement.StartMovementSkill(WorkTimeOfSkill);
    }
}
