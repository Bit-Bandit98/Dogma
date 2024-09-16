using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoverSelector : MonoBehaviour, IHoverSelect
{
    private GameObject HoveredOBJ = null;
    private IHoverable[] Cache = null;
    public void OnHover(GameObject Hovered)
    {
        if (HoveredOBJ == Hovered) return;
        if (HoveredOBJ != null)TurnOffChildren();
        HoveredOBJ = Hovered;
        TurnOnChildren();
    }
    public void OnUnHover()
    {
        if (HoveredOBJ == null) return;
        TurnOffChildren();
        HoveredOBJ = null;
    }

    private void TurnOffChildren()
    {
       Cache = HoveredOBJ.GetComponentsInChildren<IHoverable>();
        foreach(IHoverable hover in Cache)
        {
            hover.OnUnHover();
        }
    }
    private void TurnOnChildren()
    {
        Cache = HoveredOBJ.GetComponentsInChildren<IHoverable>();
        foreach (IHoverable hover in Cache)
        {
            hover.OnHover();
        }
    }

}
