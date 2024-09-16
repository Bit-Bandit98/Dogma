using UnityEngine;
public interface IIdea
{
    public NameAndDescription GetDetails();
    public Sprite GetIcon();
    public IdeologyStats GetStats();
    public ColourData GetColours();
}