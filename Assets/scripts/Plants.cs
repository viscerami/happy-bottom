using UnityEngine;

public class Plant : MonoBehaviour
{
    public int currencyValue = 1; // Сколько валюты дает это растение
    private PlayerController playerController;

    void Start()
    {
        playerController = FindObjectOfType<PlayerController>(); // Находим PlayerController
    }

    void OnMouseDown() // Обработка клика на растении
    {
        playerController.ClickOnPlant(currencyValue);
    }
}
