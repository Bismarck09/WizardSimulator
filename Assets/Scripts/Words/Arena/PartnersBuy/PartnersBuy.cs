using System;
using System.Collections;
using TMPro;
using UnityEngine;

public class PartnersBuy : MonoBehaviour
{
    [SerializeField] private Coins _coins;
    [SerializeField] private PartnerPrice _partner;
    [SerializeField] private GameObject _erroeObject;
    [SerializeField] private TextMeshProUGUI _priceOfPartnerText;
    [SerializeField] private TextMeshProUGUI _numberOfPartnersText;

    private int _numberOfPartners;

    public event Action BoughtPartner;

    private void Start()
    {
        _numberOfPartners = 0;
        _priceOfPartnerText.text = _partner.GetPriceOfPartner().ToString();
        _numberOfPartnersText.text = "0 из 4";
    }

    public void PartnerBuy()
    {
        if (_numberOfPartners < 4 && _coins.CheckCoins(_partner.GetPriceOfPartner()))
        {
            BoughtPartner?.Invoke();

            _numberOfPartners++;
            _numberOfPartnersText.text = _numberOfPartners + " из 4";
        }
        else
        {
            StartCoroutine(EnableError());
        }
    }

    private IEnumerator EnableError()
    {
        _erroeObject.SetActive(true);

        yield return new WaitForSeconds(1);
        _erroeObject.SetActive(false);
    }
}
