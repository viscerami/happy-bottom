using UnityEngine;
using UnityEngine.UI; // ����������� ��� ������ � UI
using TMPro; // ����������� ��� ������ � TextMeshPro

public class ShopWindowController : MonoBehaviour
{
    public GameObject shopPanel; // ������ �� ������ ��������
    public ShopController shopController; // ������ �� ShopController

    private void Start()
    {
        shopPanel.SetActive(false); // �������� ������ ��� ������
    }

    public void OpenShop()
    {
        shopPanel.SetActive(true); // ���������� ������ ��������
    }

    public void CloseShop()
    {
        shopPanel.SetActive(false); // �������� ������ ��������
    }

    public void BuyPlant(int plantIndex)
    {
        shopController.BuyPlant(plantIndex); // �������� ��������
        CloseShop(); // ��������� ������ ����� �������
    }
}
