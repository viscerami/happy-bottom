using UnityEngine;
using TMPro; 

public class PlayerController : MonoBehaviour
{
    public int currency = 0; 
    public TextMeshProUGUI currencyText; 

   
    public void ClickOnPlant(int value)
    {
        currency += value;
        UpdateCurrencyUI();
    }

    
    public void UpdateCurrencyUI() 
    {
        currencyText.text = " " + currency;
    }
}
