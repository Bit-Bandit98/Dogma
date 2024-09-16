using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Offsetter : MonoBehaviour
{
    [SerializeField] private Vector2 OffsetValue;
    [SerializeField] private Renderer Rend;
    

    private void Update()
    {
        OffsetTexture();
        RectifyOffset();
    }

    private void OffsetTexture()
    {
        Vector2 TempOffset = Rend.material.GetTextureOffset("_MainTex") + OffsetValue *Time.deltaTime;
        Rend.material.SetTextureOffset("_MainTex", TempOffset);
       
    }

    private void RectifyOffset()
    {
        Vector2 TempOffset = Rend.material.GetTextureOffset("_MainTex");
        
        if(TempOffset.x > 100)
        {
            TempOffset -= new Vector2(100, 0);
            
        }
        if(TempOffset.y > 100)
        {
            TempOffset -= new Vector2(0, 100);
        }
        Rend.material.SetTextureOffset("_MainTex", TempOffset);
    }
}