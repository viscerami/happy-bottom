using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI; // ����������� ��� ������ � UI

public class PlantButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject plantImage; // ������ �� ����������� ��������

    // ����� ����������, ����� ������ ������ � ������� ������
    public void OnPointerEnter(PointerEventData eventData)
    {
        plantImage.SetActive(true); // ���������� �����������
    }

    // ����� ����������, ����� ������ �������� ������� ������
    public void OnPointerExit(PointerEventData eventData)
    {
        plantImage.SetActive(false); // �������� �����������
    }
}
