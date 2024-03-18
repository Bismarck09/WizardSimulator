using UnityEngine;

public class ExitGame : MonoBehaviour
{
    private void SaveData()
    {
        PlayerPrefs.SetInt("NumberOfCoins", Progress.Instance.Coins);
        PlayerPrefs.SetInt("NumberOfExperience", Progress.Instance.Experience);
        PlayerPrefs.SetInt("PlayerLevel", Progress.Instance.PlayerLevel);
        PlayerPrefs.SetInt("DamageMagicLevel", Progress.Instance.DamageMagicLevel);
        PlayerPrefs.SetInt("SpeedMovementSkill", 0);
    }

    private void OnApplicationFocus(bool focus)
    {
        if (!focus)
        {
            SaveData();
        }
    }
}
