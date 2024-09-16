using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Highlighter : MonoBehaviour, IHoverable
{
    [SerializeField] private Color HighlightColor;
    [SerializeField] private float HighlightSpeed = 1f;

    [SerializeField] private Renderer MaterialRender = null;
    private float Timer = 0f;

    public void OnHover()
    {

        Highlight(true);
    }

    public void OnUnHover()
    {
        Highlight(false);
    }

    private void Awake()
    {
   
        foreach (Material GivenMaterial in MaterialRender.materials)
        {
            GivenMaterial.EnableKeyword("_EMISSION");
        }
    }

    private void Highlight(bool On)
    {
        StopAllCoroutines();

        if (On) StartCoroutine(ChangeToHighlight());
        else StartCoroutine(ChangeToDefault());
    }
    private IEnumerator ChangeToHighlight()
    {
        Color LerpColor;
        while (Timer < 1f)
        {
            foreach (Material GivenMaterial in MaterialRender.materials)
            {
                LerpColor = Color.Lerp(Color.black, HighlightColor, Timer);
                GivenMaterial.SetColor("_EmissionColor", LerpColor);

            }

            Timer += Time.deltaTime * HighlightSpeed;
            yield return null;
        }
    }
    private IEnumerator ChangeToDefault()
    {
        Color LerpColor;
        Color CurrentColor = MaterialRender.material.GetColor("_EmissionColor");
        while (Timer > 0f)
        {
            foreach (Material GivenMaterial in MaterialRender.materials)
            {
                LerpColor = Color.Lerp(Color.black, CurrentColor, Timer);
                GivenMaterial.SetColor("_EmissionColor", LerpColor);

            }
            Timer -= Time.deltaTime * HighlightSpeed;
            yield return null;
        }
    }
}