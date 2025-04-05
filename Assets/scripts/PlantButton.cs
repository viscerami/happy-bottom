using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI; // Импортируем для работы с UI

public class PlantButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject plantImage; // Ссылка на изображение растения

    // Метод вызывается, когда курсор входит в область кнопки
    public void OnPointerEnter(PointerEventData eventData)
    {
        plantImage.SetActive(true); // Показываем изображение
    }

    // Метод вызывается, когда курсор покидает область кнопки
    public void OnPointerExit(PointerEventData eventData)
    {
        plantImage.SetActive(false); // Скрываем изображение
    }
}
