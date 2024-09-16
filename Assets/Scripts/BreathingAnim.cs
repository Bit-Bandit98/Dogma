using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BreathingAnim : MonoBehaviour
{
    [SerializeField] private float Speed = 1f, MinimumOpacity = 0.50f;
    private Image GivenImage;
    private void OnEnable()
    {
        GivenImage = GetComponent<Image>();
        StopAllCoroutines();
        StartCoroutine(Breath());    
    }

    private IEnumerator Breath()
    {

        while (true)
        {
            float Timer = 0f;

            while(Timer < 1f)
            {
                GivenImage.color = new Color(GivenImage.color.r, GivenImage.color.g, GivenImage.color.b, 1 - (MinimumOpacity * Timer));
                Timer += Time.deltaTime * Speed;
                yield return null;
            }
            while (Timer > 0f)
            {
                GivenImage.color = new Color(GivenImage.color.r, GivenImage.color.g, GivenImage.color.b, 1f - (MinimumOpacity * Timer));
                Timer -= Time.deltaTime * Speed;
                yield return null;
            }

            yield return null;
        }
    }
}
