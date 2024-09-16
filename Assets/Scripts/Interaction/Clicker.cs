using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clicker : MonoBehaviour, IClicker
{
    public void OnClick(GameObject ClickedOBJ)
    {
        foreach(IClickable Clickable in ClickedOBJ.GetComponentsInChildren<IClickable>())
        {
            Clickable.OnClick();
        }
    }
}
