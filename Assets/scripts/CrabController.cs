using UnityEngine;

public class CrabController : MonoBehaviour
{
    public ShopWindowController shopWindowController; // ������ �� ShopWindowController

    void OnMouseDown() // ��������� ����� �� ����-����������
    {
        shopWindowController.OpenShop(); // ��������� ���� ��������
    }
}
