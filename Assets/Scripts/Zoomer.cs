using UnityEngine;
using System.Collections;
public class Zoomer : MonoBehaviour
{
    [SerializeField] private float Sensitivity = 1f, ZoomSpeed = 1f;
    [SerializeField] private Vector2Int MinMaxZoom;
    private Vector3 TargetZoomLevel;
    private int ZoomLevel = 5;
    private void Awake()
    {
        TargetZoomLevel = transform.localPosition;
    }
    private void Update()
    {
        ScrollIn();
    }

    private void ScrollIn()
    {
        if (Mathf.Abs(Input.mouseScrollDelta.y) < 1) return;
        if (SetZoomLevel((int)Input.mouseScrollDelta.y)) {
            StopAllCoroutines();
            TargetZoomLevel += transform.TransformDirection(new Vector3(0, 0, Input.mouseScrollDelta.y * Sensitivity));
            StartCoroutine(ZoomAnim(TargetZoomLevel));
        }

    }

    public void ButtonScroll(int Value)
    {
        if (Mathf.Abs(Value) < 1) return;
        if (SetZoomLevel(Value))
        {
            StopAllCoroutines();
            TargetZoomLevel += transform.TransformDirection(new Vector3(0, 0, Value * Sensitivity));
            StartCoroutine(ZoomAnim(TargetZoomLevel));
        }

    }
    private bool SetZoomLevel(int Value)
    {
        ZoomLevel += Value;
        if (ZoomLevel < MinMaxZoom.x)
        {
            ZoomLevel = MinMaxZoom.x;
            return false;
        }
        if (ZoomLevel > MinMaxZoom.y)
        {
            ZoomLevel = MinMaxZoom.y;
            return false;
        }
        return true;
    }

    private IEnumerator ZoomAnim(Vector3 Target)
    {
        float Timer = 0f;
        Vector3 StartPos = transform.localPosition;
        while(Timer < 1f)
        {
            transform.localPosition = Vector3.Lerp(StartPos, Target, Timer);
            Timer += Time.deltaTime * ZoomSpeed;
            yield return null;
        }
    }
}
