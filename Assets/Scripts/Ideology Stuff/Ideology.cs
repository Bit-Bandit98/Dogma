using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Ideology", menuName = "ScriptableObjects/Ideology")]
public class Ideology : ScriptableObject, IIdea
{
    [SerializeField] private NameAndDescription Details = null;
    [SerializeField, TextArea] private string AbilityText = null;
    [SerializeField] private IconGraphics Iconography = null;
    [SerializeField] private ColourData Colours = null;
    [SerializeField] private IdeologyStats Stats;
    [HideInInspector] public bool IsInUse = false;
    public NameAndDescription GetDetails() { return Details; }
    public Sprite GetIcon() { return Iconography.GetIcon(); }
    public ColourData GetColours() { return Colours; }
    public string GetAbilityText() { return AbilityText; }
    public IdeologyStats GetStats() { return Stats; }
}