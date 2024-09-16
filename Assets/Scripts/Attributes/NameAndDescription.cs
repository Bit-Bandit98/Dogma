using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class NameAndDescription
{
    [SerializeField] private string Name = "Default";
    [SerializeField, TextArea] private string Description = "Default";

    public string GetName() { return Name; }
    public string GetDescription() { return Description; }
}