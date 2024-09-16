using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TutorialOption : MonoBehaviour
{
    [SerializeField] private Toggle TogglingObj = null;
    private void OnEnable()
    {
        TogglingObj.isOn = !TutorialSettings.TutorialFinished;
    }
    public void SetTutorialOption()
    {
       TutorialSettings.TutorialFinished = !TogglingObj.isOn;
    }
}
