using UnityEngine;

public class Plant : MonoBehaviour
{
    public int currencyValue = 1; // ������� ������ ���� ��� ��������
    private PlayerController playerController;

    void Start()
    {
        playerController = FindObjectOfType<PlayerController>(); // ������� PlayerController
    }

    void OnMouseDown() // ��������� ����� �� ��������
    {
        playerController.ClickOnPlant(currencyValue);
    }
}
