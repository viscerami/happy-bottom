using UnityEngine;
using TMPro;

public class ShopController : MonoBehaviour
{
    public Plant[] availablePlants;
    public PlayerController playerController;
    public TextMeshProUGUI shopMessage;

    private GameObject currentPlantPrefab;
    private GameObject currentPlantInstance;

    private void Start()
    {
        if (availablePlants.Length > 0)
        {
            availablePlants[0].isUnlocked = true;
        }
        UpdatePlantIcons();
    }

    public void BuyPlant(int plantIndex)
    {
        if (!availablePlants[plantIndex].isUnlocked)
        {
            shopMessage.text = "This plant is not yet available for purchase";
            return;
        }

        if (playerController.currency >= availablePlants[plantIndex].purchaseCost)
        {
            playerController.currency -= availablePlants[plantIndex].purchaseCost;
            shopMessage.text = "You bought a seed ";
            playerController.UpdateCurrencyUI();

            currentPlantPrefab = availablePlants[plantIndex].gameObject;
            SetupPlantToPlace();
        }
        else
        {
            shopMessage.text = "Not enough currency";
        }
    }

    private void SetupPlantToPlace()
    {
        currentPlantInstance = Instantiate(currentPlantPrefab);
        currentPlantInstance.SetActive(true);
        currentPlantInstance.transform.position = GetMousePosition();
    }

    private void Update()
    {
        if (currentPlantInstance != null)
        {
            currentPlantInstance.transform.position = GetMousePosition();

            if (Input.GetMouseButtonDown(1))
            {
                PlacePlant();
            }
        }
    }

    private void PlacePlant()
    {
        currentPlantInstance.AddComponent<DragAndDropPlant>();
        currentPlantPrefab = null;
        currentPlantInstance = null;
    }

    private Vector3 GetMousePosition()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;
        return mousePos;
    }

    public void UnlockNextPlant(int currentIndex)
    {
        if (currentIndex + 1 < availablePlants.Length)
        {
            availablePlants[currentIndex + 1].isUnlocked = true;
            UpdatePlantIcons();
        }
    }

    private void UpdatePlantIcons()
    {
        for (int i = 0; i < availablePlants.Length; i++)
        {
            availablePlants[i].isUnlocked = i == 0 || availablePlants[i - 1].isUnlocked;
        }
    }
}
