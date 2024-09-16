using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowCloser : MonoBehaviour
{
    [SerializeField] private GameObject Window = null;
    public void CloseWindow()
    {
        Window.SetActive(!Window.activeInHierarchy);
    }
}
