using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class Targeter : MonoBehaviour
{
    [HideInInspector] public static bool InTargetMode = false;
    private static GameObject Target = null;
    public delegate void TargetMode();
    public static event TargetMode OnTargetEnter;
    public static event TargetMode TargetPayload;
    public static event TargetMode OnTargetExit;
    public static Targeter Singleton = null;
    public enum TargetType { Travel, Attack}
    public static TargetType TargetOBJState = TargetType.Travel;
    public static void EnterTargetMode(TargetType TT)
    {
        TargetOBJState = TT;
        InTargetMode = true;
        InvokeOnTargetEnter();
    }
    
    public static void SetTarget(GameObject OBJ)
    {
        if (!InTargetMode) return;
        Target = OBJ;
        if (Target == null) return;
        ITargetable TempItarget = Target.transform.root.GetComponentInChildren<ITargetable>();
        if (TempItarget != null)
        {
            if (!TempItarget.CheckIfAvailable()) return;
            if (TempItarget.GetOBJIfCorrectType(TargetOBJState) == null) return;
            ExitTargetMode();
        }
        
    }

    public static GameObject GetTarget() { return Target; }

    private static void ExitTargetMode()
    {
        if(Target != null) InvokePayload();
        InTargetMode = false;
        Target = null;
        InvokeOnTargetExit();
    }

  
    public void ExitTargetNoTarget()
    {
        InTargetMode = false;
        Target = null;
        InvokeOnTargetExit();
    }
    public void ExitTargetModeCaller()
    {
        ExitTargetMode();
    }
    private static void InvokePayload() { if (TargetPayload != null) TargetPayload.Invoke();
        TargetPayload = null;
    }
    private static void InvokeOnTargetEnter() { if (OnTargetEnter != null) OnTargetEnter.Invoke(); }
    private static void InvokeOnTargetExit() { if (OnTargetExit != null) OnTargetExit.Invoke(); }
}