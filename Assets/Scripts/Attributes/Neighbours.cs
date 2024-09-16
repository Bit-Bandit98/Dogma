
using UnityEngine;

[System.Serializable]
public class Neighbours<T>
{
    [SerializeField] private T[] ExistingNeighbours = null;

    public T[] GetNeighbours() { return ExistingNeighbours; }
}