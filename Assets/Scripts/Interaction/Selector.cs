using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selector : MonoBehaviour, ISelector
{
    private GameObject SelectedOBJ = null;
    public delegate void Selection();
    public static event Selection OnSelected;

    public void OnSelect(RaycastHit Selected)
    {
        if (NullCheck(Selected.collider)) return;
        if (SameOBJCheck(Selected.collider.gameObject)) return;
        OnDeSelect();
        SelectObject(Selected);
    } 

    private void SelectObject(RaycastHit Selected)
    {
        SelectedOBJ = Selected.collider.gameObject;
        foreach(ISelectable ISelect in SelectedOBJ.GetComponentsInChildren<ISelectable>())
        {
            ISelect.OnSelect();
        }
        
        InvokeOnSelected();
    }

    public void OnDeSelect()
    {
        if (SelectedOBJ == null) return;
        foreach (ISelectable ISelect in SelectedOBJ.GetComponentsInChildren<ISelectable>())
        {
            ISelect.OnDeselect();
        }
       
        SelectedOBJ = null;
    }

    private bool NullCheck(Collider OBJ)
    {
        if (OBJ == null)
        {
            OnDeSelect();
            InvokeOnSelected();
            return true;
        }
        return false;
    }
    private bool SameOBJCheck(GameObject OBJ){return OBJ == SelectedOBJ;}

    public GameObject GetSelected() { return SelectedOBJ; }
    public void InvokeOnSelected() { if (OnSelected != null) OnSelected.Invoke(); }
}