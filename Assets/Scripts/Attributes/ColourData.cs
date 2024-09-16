using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ColourData 
{
    [SerializeField] private Color MainColour, SecondaryColour;


    public Color GetMainColour() { return MainColour; }
    public Color GetSecondaryColour() { return SecondaryColour; }
}
