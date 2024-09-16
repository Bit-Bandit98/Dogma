using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using cakeslice;

public class SelectionOutline : MonoBehaviour, ISelectable
{
    [SerializeField] private Outline OutlineToSelect = null;


    private void Start()
    {
        SetOutline(false);
    }
    public void OnDeselect()
    {
        SetOutline(false);
    }

    public void OnSelect()
    {
        SetOutline(true);
    }

    public void SetOutline(bool Condition)
    {
        OutlineToSelect.enabled = Condition;
    }

}