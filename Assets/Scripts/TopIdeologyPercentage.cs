using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class TopIdeologyPercentage : MonoBehaviour
{
    [SerializeField] private GameObject MainPanel = null;
    [SerializeField] private InfluenceSystem ConnectedIS = null;
    [SerializeField] private TextMeshProUGUI PercentageValue = null;
    [SerializeField] private Slider Progress = null;
    [SerializeField] private Image ProgressColor = null;
    private float CurrentValue = 0f;

    private void Awake()
    {
        ConnectedIS.OnUpdate += UpdatePercentage;
        ConnectedIS.GetDiscoverState().OnDiscovery += UpdatePercentage;
    }

    private void UpdatePercentage()
    {
        if (!ConnectedIS.GetDiscoverState().GetIsDiscovered())
        {
            MainPanel.SetActive(false);   
            return;
        }
        MainPanel.SetActive(true);
        StopAllCoroutines();
        float Percentage = (float)ConnectedIS.GetListOfIdeologies().GetFollowedIdeologies()[0].GetFollowers() / 
        (float)ConnectedIS.GetSituatedIn().GetPopulation() *100;
        float StartingValue = CurrentValue;
        CurrentValue = Percentage;
        StartCoroutine(ChangeColour(ProgressColor.color, ConnectedIS.GetTopIdeology().GetColours().GetMainColour()));
        StartCoroutine(ChangeText(StartingValue, CurrentValue));
    }

    private IEnumerator ChangeText(float StartingValue, float EndValue)
    {
        float Timer = 0f;
        float NewValue = 0f;
      
        while(Timer < 1f)
        {
            NewValue = Mathf.Lerp(StartingValue, EndValue, Timer * Timer * (3 * Timer - 2 * Timer * Timer));
            PercentageValue.text = NewValue.ToString("F0") + "%";
            Progress.value = NewValue/100;
            //y = x^2* (3x - 2x * x)
            Timer += Time.deltaTime;
          
            yield return null;
        }
        PercentageValue.text = EndValue + "%";
    }


    private IEnumerator ChangeColour(Color StartingColor,Color TargetColor)
    {
        float Timer = 0f;
        Color NewColor;
        while (Timer < 1f)
        {
            NewColor = Color.Lerp(StartingColor, TargetColor, Timer * Timer * (3 * Timer - 2 * Timer * Timer));
            ProgressColor.color = NewColor;
            Timer += Time.deltaTime;

            yield return null;
        }
    }
}
