using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class CountryUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI CountryName = null, Population = null;
    private Country ConnectedCountry;
    private Discoverability CountryDiscoverStatus;
    private void Awake()
    {
         ConnectedCountry = gameObject.transform.root.GetComponentInChildren<Country>();
    }
    private void Start()
    {
        CountryDiscoverStatus = ConnectedCountry.GetDiscoverState();
        CountryDiscoverStatus.OnDiscovery += UpdateText;
        UpdateText();
    }
    private void OnDisable()
    {
        CountryDiscoverStatus.OnDiscovery -= UpdateText;
    }

    private void UpdateText()
    {
     if(CountryDiscoverStatus.GetIsDiscovered()) {   
        CountryName.text = ConnectedCountry.GetDetails().GetName();
        Population.text = ConnectedCountry.GetPopulation().ToString();
        CountryDiscoverStatus.OnDiscovery -= UpdateText;
        } else
        {
            CountryName.text = "???";
            Population.text = "??";
        }
    }
}