using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Fader : MonoBehaviour
{
    [SerializeField] private Image FadePanel = null;

    private void Start()
    {
        
            Fader[] objs = GameObject.FindObjectsOfType<Fader>();

            if (objs.Length > 1)
            {
                Destroy(this.gameObject);
            }

            DontDestroyOnLoad(this.gameObject);

        FadeOut();
    }

    public void FadeOut()
    {
        Color OutColor = new Color(0, 0, 0, 0);
       StartCoroutine(BeginFade(Color.black, OutColor));
    }

    public void FadeIn()
    {
        Color InColor = new Color(0, 0, 0, 1);
        StartCoroutine(BeginFade(Color.clear,InColor));
    }

    private IEnumerator BeginFade(Color StartingColor, Color TargetColor)
    {
        float Timer = 0f;
        
        while(Timer < 1f)
        {
            FadePanel.color = Color.Lerp(StartingColor, TargetColor, Timer);
            Timer += Time.deltaTime;
            yield return null;
        }
    }


}
