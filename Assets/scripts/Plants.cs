using UnityEngine;

public class Plant : MonoBehaviour
{
    public int currencyValue = 1; // Сколько валюты дает это растение
    public Sprite seedSprite; // Спрайт для семечка
    public Sprite sproutSprite; // Спрайт для ростка
    public Sprite adultPlantSprite; // Спрайт для взрослого растения
    public AudioClip clickSound; // Звук щелчка
    private AudioSource audioSource; // Ссылка на AudioSource

    private PlayerController playerController;
    private SpriteRenderer spriteRenderer; // Компонент SpriteRenderer для изменения спрайта

    private int growthStage = 0; // Текущая стадия роста (0 - семечко, 1 - росток, 2 - взрослое растение)
    private int clickCount = 0; // Счетчик кликов

    public bool isAvailable = false; // Доступно ли растение для покупки
    public bool isUnlocked = false; // Доступно ли растение для покупки (разблокировано)

    public int purchaseCost = 10; // Стоимость покупки растения

    void Start()
    {
        playerController = FindObjectOfType<PlayerController>(); // Находим PlayerController
        spriteRenderer = GetComponent<SpriteRenderer>(); // Получаем компонент SpriteRenderer
        audioSource = gameObject.AddComponent<AudioSource>(); // Добавляем компонент AudioSource
        audioSource.clip = clickSound; // Устанавливаем звуковой файл
        spriteRenderer.sprite = seedSprite; // Устанавливаем спрайт семечка
    }

    void OnMouseDown() // Обработка клика на растении
    {
        audioSource.Play(); // Воспроизводим звук при клике
        playerController.ClickOnPlant(currencyValue);
        clickCount++; // Увеличиваем счетчик кликов

        // Проверяем, достигли ли мы следующей стадии роста
        if (clickCount >= 25)
        {
            GrowPlant();
            clickCount = 0; // Сбрасываем счетчик кликов
        }
    }

    private void GrowPlant()
    {
        growthStage++; // Переходим к следующей стадии роста

        // Изменяем внешний вид растения в зависимости от стадии роста
        switch (growthStage)
        {
            case 1:
                spriteRenderer.sprite = sproutSprite; // Устанавливаем спрайт ростка
                Debug.Log("Растение выросло в росток!");
                break;
            case 2:
                spriteRenderer.sprite = adultPlantSprite; // Устанавливаем спрайт взрослого растения
                isAvailable = true; // Теперь растение доступно для покупки
                isUnlocked = true; // Разблокируем растение
                Debug.Log("Растение выросло в взрослое растение!");

                // Разблокируем следующее растение в магазине
                ShopController shopController = FindObjectOfType<ShopController>();
                if (shopController != null)
                {
                    shopController.UnlockNextPlant(FindPlantIndex());
                }
                break;
            default:
                Debug.Log("Растение достигло максимальной стадии роста.");
                break;
        }
    }

    private int FindPlantIndex()
    {
        // Находим индекс текущего растения в массиве availablePlants
        ShopController shopController = FindObjectOfType<ShopController>();
        for (int i = 0; i < shopController.availablePlants.Length; i++)
        {
            if (shopController.availablePlants[i] == this)
            {
                return i; // Возвращаем индекс текущего растения
            }
        }
        return -1; // Если не найдено, возвращаем -1
    }
}
