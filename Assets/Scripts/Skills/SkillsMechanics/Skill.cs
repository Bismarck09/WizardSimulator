using System.Collections;
using TMPro;
using UnityEngine;

public abstract class Skill : MonoBehaviour
{
    public abstract TextMeshProUGUI RemainingReloadTimeText { get; set; }
    public abstract float ReloadTime { get; set; }
    public abstract float RemainingReloadTime {  get; set; }
    public abstract float TimeElapsed { get; set; }
    public abstract float WorkTimeOfSkill { get; set; }
    public abstract bool IsActive { get; set; }
    public abstract bool IsEnable { get; set; }


    public virtual void EnableSkill()
    {
        if (IsActive && IsEnable)
        {
            IsActive = false;
            StartCoroutine(UseSkill());
        }
    }

    public virtual void RunReloadSkill()
    {
        StartCoroutine(ReloadSkill(RemainingReloadTime));
    }

    public abstract void WorkOfSkill();

    private IEnumerator UseSkill()
    {
        WorkOfSkill();
        
        yield return new WaitForSeconds(WorkTimeOfSkill);
        StartCoroutine(ReloadSkill(ReloadTime));
    }

    private IEnumerator ReloadSkill(float reloadTime)
    {
        TimeElapsed = 0;
        while (TimeElapsed < reloadTime)
        {
            yield return new WaitForSeconds(1);
            TimeElapsed++;

            RemainingReloadTime = reloadTime - TimeElapsed;
            RemainingReloadTimeText.text = RemainingReloadTime.ToString();
        }
        IsActive = true;
    }
}
