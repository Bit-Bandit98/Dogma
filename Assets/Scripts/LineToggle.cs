using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineToggle : MonoBehaviour, ISelectable, IClickable
{
    [SerializeField] private InfluenceSystem ConnectedIS = null;
   
    public void OnClick()
    {
        
        OnSelect();
    }

    public void OnDeselect()
    {
        if (!ConnectedIS.GetDiscoverState().GetIsDiscovered()) return;
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(false);
        }
       
    }

    public void OnSelect()
    {
        if (!ConnectedIS.GetDiscoverState().GetIsDiscovered()) return;
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(true);
        }
       
    }
}
