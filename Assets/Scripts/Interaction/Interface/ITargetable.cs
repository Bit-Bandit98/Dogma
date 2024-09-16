using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ITargetable
{
    public void OnEnterTargeting();
    public void OnExitTargeting();
    public bool CheckIfAvailable();
    public GameObject GetOBJIfCorrectType(Targeter.TargetType Type);
}