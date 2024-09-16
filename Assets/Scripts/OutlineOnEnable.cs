using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutlineOnEnable : MonoBehaviour
{
    [SerializeField] private SelectionOutline SO = null;
    private void OnEnable()
    {
        SO.SetOutline(false);
    }
}
