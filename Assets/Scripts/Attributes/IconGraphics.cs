using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class IconGraphics
{
    [SerializeField] private Sprite Icon = null;

    public IconGraphics(Sprite GivenIcon)
    {
        Icon = GivenIcon;
    }
    public Sprite GetIcon() { return Icon; }
}
