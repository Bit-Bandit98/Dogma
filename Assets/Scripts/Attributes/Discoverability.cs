using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Discoverability : MonoBehaviour
{
    [SerializeField] private bool IsDiscovered = false;
    public delegate void Discovered();
    public event Discovered OnDiscovery;
    public void Discover() {
        if (IsDiscovered) return;
        IsDiscovered = true;
        InvokeOnDiscover();
    }
    public bool GetIsDiscovered() { return IsDiscovered; }

    private void InvokeOnDiscover() { if(OnDiscovery != null) OnDiscovery.Invoke(); }
}