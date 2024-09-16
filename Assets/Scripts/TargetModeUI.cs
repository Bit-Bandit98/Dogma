using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetModeUI : MonoBehaviour
{
    private GameObject UiObject = null;
    [SerializeField] UiMover Mover = null;
    private void Awake()
    {
        if(transform.childCount > 0) UiObject = transform.GetChild(0).gameObject;
    }

    private void OnEnable()
    {
        Targeter.OnTargetEnter += WhenEnterTargetMode;
        Targeter.OnTargetExit += WhenExitTargetMode;
    }
    private void OnDisable()
    {
        Targeter.OnTargetEnter -= WhenEnterTargetMode;
        Targeter.OnTargetExit -= WhenExitTargetMode;
    }
    private void WhenEnterTargetMode()
    {
        UiObject.SetActive(true);
    }

    private void WhenExitTargetMode()
    {
        Mover.LerpInOrOut(false);
    }
}
