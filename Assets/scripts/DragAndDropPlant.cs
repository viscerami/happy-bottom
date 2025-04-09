using UnityEngine;
using UnityEngine.EventSystems;

public class DragAndDropPlant : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private Vector3 offset;

    public void OnBeginDrag(PointerEventData eventData)
    {
        
        offset = transform.position - GetMouseWorldPosition(eventData);
    }

    public void OnDrag(PointerEventData eventData)
    {
        
        transform.position = GetMouseWorldPosition(eventData) + offset;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        
    }

    private Vector3 GetMouseWorldPosition(PointerEventData eventData)
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(eventData.position);
        mousePos.z = 0; 
        return mousePos;
    }
}
