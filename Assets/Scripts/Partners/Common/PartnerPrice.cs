using UnityEngine;

public class PartnerPrice : MonoBehaviour
{
    [SerializeField] private int[] _priceOfPartners;

    public int GetPriceOfPartner()
    {
        return _priceOfPartners[Progress.Instance.PlayerLevel];
    }
}
