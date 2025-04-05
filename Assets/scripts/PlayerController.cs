using UnityEngine;
using TMPro; // Импортируем пространство имен для TMP

public class PlayerController : MonoBehaviour
{
    public int currency = 0; // Текущая валюта
    public TextMeshProUGUI currencyText; // TMP текст для валюты

    // Увеличиваем валюту при клике на растение
    public void ClickOnPlant(int value)
    {
        currency += value;
        UpdateCurrencyUI();
    }

    // Обновляем текст валюты на экране
    public void UpdateCurrencyUI() // Изменено на public
    {
        currencyText.text = "Currency: " + currency;
    }
}
