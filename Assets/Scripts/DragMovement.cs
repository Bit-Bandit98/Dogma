using UnityEngine;
using UnityEngine.EventSystems;
public class DragMovement : MonoBehaviour
{
    [SerializeField] private float Speed = 1f;
    [SerializeField] private Vector3 ClickPos;
    public static bool Dragging = false;
    private bool ClickDragging = false;

    void Update()
    {
        if (EventSystem.current.IsPointerOverGameObject()) return;
        Clicking();
        Movement();
    }

    private void Movement()
    {
        if(ClickDragging && (Vector3.Distance(ClickPos, Input.mousePosition)) > 10f)
        {
            if (!Input.GetMouseButton(0)) return;
            Dragging = true;
            Vector3 AddPosition = new Vector3(-Input.GetAxis("Mouse X"), 0, -Input.GetAxis("Mouse Y")) * Speed;
            AddPosition = transform.TransformDirection(AddPosition);
            transform.localPosition += AddPosition * Time.deltaTime;
        }
        else Dragging = false;
        
    
    }

    private void Clicking()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ClickDragging = true;
            ClickPos = Input.mousePosition; 
        }

        if (Input.GetMouseButtonUp(0))
        {
            ClickDragging = false;
        }
    }
}