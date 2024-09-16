using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayCycle : MonoBehaviour
{
    [SerializeField] private float TargetValue = 1f;
    [SerializeField] private float Speed = 1f;
    private float StartValue = 1f;
    private Light GivenLight = null;

    private void Start()
    {
        GivenLight = GetComponent<Light>();
        StartValue = GivenLight.intensity;
    }
    public void StartCycle()
    {
        StopAllCoroutines();
        StartCoroutine(AdvanceTime());

    }

    private IEnumerator AdvanceTime()
    {

        float Timer = 0f;
        while(Timer < 1f)
        {
            GivenLight.intensity = Mathf.Lerp(StartValue, TargetValue, Timer);
            Timer += Time.deltaTime * Speed;
            yield return null;
        }
        while (Timer > 0f)
        {
            GivenLight.intensity = Mathf.Lerp(StartValue, TargetValue, Timer);
            Timer -= Time.deltaTime *Speed;
            yield return null;
        }

    }
}
