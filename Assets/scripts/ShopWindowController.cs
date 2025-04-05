using UnityEngine;
using UnityEngine.UI; // Импортируем для работы с UI
using TMPro; // Импортируем для работы с TextMeshPro

public class ShopWindowController : MonoBehaviour
{
    public GameObject shopPanel; // Ссылка на панель магазина
    public ShopController shopController; // Ссылка на ShopController

    private void Start()
    {
        shopPanel.SetActive(false); // Скрываем панель при старте
    }

    public void OpenShop()
    {
        shopPanel.SetActive(true); // Показываем панель магазина
    }

    public void CloseShop()
    {
        shopPanel.SetActive(false); // Скрываем панель магазина
    }

    public void BuyPlant(int plantIndex)
    {
        shopController.BuyPlant(plantIndex); // Покупаем растение
        CloseShop(); // Закрываем панель после покупки
    }
}
