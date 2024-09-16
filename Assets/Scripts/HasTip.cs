using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HasTip : MonoBehaviour, IHoverable
{
    [SerializeField] private string Tip;
    [SerializeField] private bool UseGMName = true;
    public void OnHover()
    {
        if (MouseTip.Singleton != null)
        {

            if (UseGMName) MouseTip.Singleton.SetToolText(transform.root.name);
            else MouseTip.Singleton.SetToolText(Tip);
        }
    }

    public void OnUnHover()
    {
        if (MouseTip.Singleton != null)
        {
             MouseTip.Singleton.TurnOffToolText();
        }
    }

}
