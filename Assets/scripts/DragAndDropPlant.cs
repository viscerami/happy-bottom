using UnityEngine;
using UnityEngine.EventSystems;

public class DragAndDropPlant : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private Vector3 offset;

    public void OnBeginDrag(PointerEventData eventData)
    {
        // Расчет смещения при начале перетаскивания
        offset = transform.position - GetMouseWorldPosition(eventData);
    }

    public void OnDrag(PointerEventData eventData)
    {
        // Изменяем позицию объекта при перетаскивании
        transform.position = GetMouseWorldPosition(eventData) + offset;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        // Действия после завершения перетаскивания, если это нужно
    }

    private Vector3 GetMouseWorldPosition(PointerEventData eventData)
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(eventData.position);
        mousePos.z = 0; // Убедитесь, что Z = 0
        return mousePos;
    }
}
