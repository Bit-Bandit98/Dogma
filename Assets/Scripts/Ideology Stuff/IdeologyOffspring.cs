using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdeologyOffspring : IIdea
{
    [SerializeField] private NameAndDescription Details = null;
    [SerializeField] private IconGraphics Iconography = null;
    [SerializeField] private ColourData Colours = null;
    [SerializeField] private IdeologyStats Stats = null;
    public IdeologyOffspring(IIdea GivenIdeology)
    {
        Details = GivenIdeology.GetDetails();
        Iconography = new IconGraphics(GivenIdeology.GetIcon());
        Colours = GivenIdeology.GetColours();
        Stats = GivenIdeology.GetStats();

    }
    public NameAndDescription GetDetails() { return Details; }
    public Sprite GetIcon() { return Iconography.GetIcon(); }
    public ColourData GetColours() { return Colours; }
    public IdeologyStats GetStats() { return Stats; }
    public static bool operator ==(IdeologyOffspring A, IdeologyOffspring B)
    {
        return Equals(A, B);

    }

    public static bool operator !=(IdeologyOffspring A, IdeologyOffspring B)
    {
        return !Equals(A, B);
    }

}