using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiMover : MonoBehaviour
{
    [SerializeField] public Vector3 StartPos, EndPos;
    [SerializeField] private float Speed = 1f;
    [HideInInspector] public bool In = false, Out = false;
    [SerializeField] private bool MoveOnEnable = false;

    private void OnEnable()
    {
        if (MoveOnEnable) LerpInOrOut(true);
    }
    private void OnDisable()
    {
        if (MoveOnEnable)
        {
            Out = true;
            In = false;
        }
    }

    private IEnumerator LerpEnter()
    {
        RectTransform RT = GetComponent<RectTransform>();
        if (In)
        {
            RT.anchoredPosition = EndPos;
            yield break;
        }
        Out = false;
        In = true;
        float Timer = 0f;
       
        while (Timer < 1f) {
            RT.anchoredPosition = Vector3.Lerp(StartPos, EndPos, Timer * Timer * (3f - 2f * Timer));
            Timer += Time.deltaTime * Speed;
            yield return null;
        }
        RT.anchoredPosition = EndPos;
    }

    private IEnumerator LerpExit()
    {
        RectTransform RT = GetComponent<RectTransform>();
        if (Out)
        {
            RT.anchoredPosition = StartPos;
            yield break;
        }
        Out = true;
        In = false;
        float Timer = 1f;
        
        while (Timer > 0f)
        {
            RT.anchoredPosition = Vector3.Lerp(StartPos, EndPos, Timer * Timer * (3f - 2f * Timer));
            Timer -= Time.deltaTime * Speed;
            yield return null;
        }
        RT.anchoredPosition = StartPos;
        if (MoveOnEnable) gameObject.SetActive(false);
      
    }

    public void LerpInOrOut(bool In)
    {
        StopAllCoroutines();
        
        if (In)
        {
            StartCoroutine(LerpEnter());
        }
        else
        {
            
            StartCoroutine(LerpExit());
        }
    }
}
