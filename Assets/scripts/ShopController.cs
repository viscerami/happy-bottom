using UnityEngine;
using TMPro;

public class ShopController : MonoBehaviour
{
    public Plant[] availablePlants; // Доступные растения
    public PlayerController playerController; // Ссылка на PlayerController
    public TextMeshProUGUI shopMessage; // Сообщение в магазине

    private GameObject currentPlantPrefab; // Хранит префаб для текущего растения
    private GameObject currentPlantInstance; // Хранит текущий экземпляр растения

    public void BuyPlant(int plantIndex)
    {
        if (playerController.currency >= availablePlants[plantIndex].currencyValue)
        {
            playerController.currency -= availablePlants[plantIndex].currencyValue; // Уменьшаем валюту
            shopMessage.text = "Вы купили " + availablePlants[plantIndex].name + "!";
            playerController.UpdateCurrencyUI(); // Обновляем UI валюты

            currentPlantPrefab = availablePlants[plantIndex].gameObject; // Устанавливаем текущий префаб
            SetupPlantToPlace(); // Настраиваем растение
        }
        else
        {
            shopMessage.text = "Недостаточно валюты!";
        }
    }

    private void SetupPlantToPlace()
    {
        // Создаем экземпляр префаба и активируем его
        currentPlantInstance = Instantiate(currentPlantPrefab);
        currentPlantInstance.SetActive(true); // Обязательно активируйте
        currentPlantInstance.transform.position = GetMousePosition(); // Позиция по курсору
    }

    private void Update()
    {
        // Проверяем, нажата ли правая кнопка мыши и есть ли текущий экземпляр растения
        if (Input.GetMouseButtonDown(1) && currentPlantInstance != null)
        {
            PlacePlant();
        }

        // Если есть текущий экземпляр растения, обновляем его позицию с курсором
        if (currentPlantInstance != null)
        {
            currentPlantInstance.transform.position = GetMousePosition(); // Обновляем позицию растения с курсором
        }
    }

    private void PlacePlant()
    {
        // Устанавливаем растение на место
        currentPlantInstance.AddComponent<DragAndDropPlant>(); // Добавляем скрипт для перемещения
        currentPlantPrefab = null; // Сбрасываем текущий префаб
        currentPlantInstance = null; // Убираем ссылку на текущий экземпляр
    }

    private Vector3 GetMousePosition()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0; // Убедитесь, что Z = 0
        return mousePos;
    }
}
