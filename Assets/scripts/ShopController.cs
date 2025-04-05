using UnityEngine;
using TMPro;

public class ShopController : MonoBehaviour
{
    public Plant[] availablePlants; // ��������� ��������
    public PlayerController playerController; // ������ �� PlayerController
    public TextMeshProUGUI shopMessage; // ��������� � ��������

    private GameObject currentPlantPrefab; // ������ ������ ��� �������� ��������
    private GameObject currentPlantInstance; // ������ ������� ��������� ��������

    public void BuyPlant(int plantIndex)
    {
        if (playerController.currency >= availablePlants[plantIndex].currencyValue)
        {
            playerController.currency -= availablePlants[plantIndex].currencyValue; // ��������� ������
            shopMessage.text = "�� ������ " + availablePlants[plantIndex].name + "!";
            playerController.UpdateCurrencyUI(); // ��������� UI ������

            currentPlantPrefab = availablePlants[plantIndex].gameObject; // ������������� ������� ������
            SetupPlantToPlace(); // ����������� ��������
        }
        else
        {
            shopMessage.text = "������������ ������!";
        }
    }

    private void SetupPlantToPlace()
    {
        // ������� ��������� ������� � ���������� ���
        currentPlantInstance = Instantiate(currentPlantPrefab);
        currentPlantInstance.SetActive(true); // ����������� �����������
        currentPlantInstance.transform.position = GetMousePosition(); // ������� �� �������
    }

    private void Update()
    {
        // ���������, ������ �� ������ ������ ���� � ���� �� ������� ��������� ��������
        if (Input.GetMouseButtonDown(1) && currentPlantInstance != null)
        {
            PlacePlant();
        }

        // ���� ���� ������� ��������� ��������, ��������� ��� ������� � ��������
        if (currentPlantInstance != null)
        {
            currentPlantInstance.transform.position = GetMousePosition(); // ��������� ������� �������� � ��������
        }
    }

    private void PlacePlant()
    {
        // ������������� �������� �� �����
        currentPlantInstance.AddComponent<DragAndDropPlant>(); // ��������� ������ ��� �����������
        currentPlantPrefab = null; // ���������� ������� ������
        currentPlantInstance = null; // ������� ������ �� ������� ���������
    }

    private Vector3 GetMousePosition()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0; // ���������, ��� Z = 0
        return mousePos;
    }
}
