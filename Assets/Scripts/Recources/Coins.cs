using TMPro;
using UnityEngine;

public class Coins : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _numberOfCoinsText;

    private int _numberOfCoins;

    private void Start()
    {
        _numberOfCoins = Progress.Instance.Coins;
        _numberOfCoinsText.text = _numberOfCoins.ToString();
    }
    
    private void ChangeData()
    {
        _numberOfCoinsText.text = _numberOfCoins.ToString();
        Progress.Instance.Coins = _numberOfCoins;
    }

    public void TakeCoins(int coins)
    {
        _numberOfCoins += coins;
        ChangeData();
    }
    
    public bool CheckCoins(int coins)
    {
        if (coins <= _numberOfCoins) 
        { 
            GiveCoins(coins);
            return true;
        }

        return false;
    }

    private void GiveCoins(int coins)
    {
        _numberOfCoins -= coins;
        ChangeData();
    }

    
}
