using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class IdeologyRatioPanel : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI Percentage = null, IdeologyName = null;
    [SerializeField] private Image IdeologyIcon = null, SliderBar = null, BackgroundPanel;
    [SerializeField] private Slider RatioBar = null;

    public void SetIdeaPanel(IdeologyicalFollowing GivenIdea, int Population)
    {
        IIdea TempIdea = GivenIdea.GetFollowedIdeology();
        float PercentageValue = (float)Math.Round(GivenIdea.GetFollowers() / (float)Population, 2);
        IdeologyName.text = TempIdea.GetDetails().GetName();
        Percentage.text = PercentageValue * 100 + "%";
        IdeologyIcon.sprite = TempIdea.GetIcon();
        BackgroundPanel.color = TempIdea.GetColours().GetMainColour();
        SliderBar.color = TempIdea.GetColours().GetSecondaryColour();
        RatioBar.value = PercentageValue;
        
    }
}
