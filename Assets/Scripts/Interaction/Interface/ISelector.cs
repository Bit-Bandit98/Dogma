using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISelector
{
    public void OnSelect(RaycastHit Selected);
    public void OnDeSelect();
    public GameObject GetSelected();
}