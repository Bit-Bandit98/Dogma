using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class TurnMasterUI : MonoBehaviour
{
    private TurnMaster TM = null;
    [SerializeField] private TextMeshProUGUI CurrentTurnText = null;
    private void OnEnable()
    {
        TM = FindObjectOfType<TurnMaster>();
        SetText();
        TurnMaster.OnNextTurn += SetText;
    }
    private void OnDisable()
    {
        TurnMaster.OnNextTurn -= SetText;
    }


    private void SetText()
    {
        CurrentTurnText.text = "Current Turn \n" + TM.GetCurrentTurn();
    }
}
