using UnityEngine;

public class OpenSkills : MonoBehaviour
{
    private EnableSkills _enableSkills;

    private void Start()
    {
        _enableSkills = GetComponent<EnableSkills>();

        _enableSkills.EnableSkill();
    }
}
