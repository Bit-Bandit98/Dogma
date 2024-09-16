using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class GraphicsDropDown : MonoBehaviour
{
    [SerializeField] private TMP_Dropdown DD = null;

    private void Start()
    {
        DD.value = QualitySettings.GetQualityLevel();
    }
    public void SetQualitySetting()
    {
       QualitySettings.SetQualityLevel(DD.value, true);
    }
}
