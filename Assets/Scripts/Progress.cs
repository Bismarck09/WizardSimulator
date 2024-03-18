using UnityEngine;

public class Progress : MonoBehaviour
{
    public int Coins;
    public int Experience;
    public int DamageMagicLevel;
    public int PlayerLevel;
    public int MaximumPlayerLevel;

    public static Progress Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            transform.parent = null;
            DontDestroyOnLoad(gameObject);
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        LoadData();
    }

    private void LoadData()
    {
        Coins = PlayerPrefs.GetInt("NumberOfCoins");
        Experience = PlayerPrefs.GetInt("NumberOfExperience");
        DamageMagicLevel = PlayerPrefs.GetInt("DamageMagicLevel");
        PlayerLevel = PlayerPrefs.GetInt("PlayerLevel");
        MaximumPlayerLevel = 4;
    }
}
