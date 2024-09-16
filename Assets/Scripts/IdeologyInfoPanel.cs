using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class IdeologyInfoPanel : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI IdeologyName, IdeologyAbility, IdeologyDescription;
    [SerializeField] private Image IdeologyImage;


    private void OnEnable()
    {
        Ideology GivenIdea = PlayerSettings.PlayerIdea;
        IdeologyName.text = GivenIdea.GetDetails().GetName();
        IdeologyDescription.text = GivenIdea.GetDetails().GetDescription();
        IdeologyAbility.text = GivenIdea.GetAbilityText();
        IdeologyImage.sprite = GivenIdea.GetIcon();
    }
}