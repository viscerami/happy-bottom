using UnityEngine;
using UnityEngine.UI; 
using TMPro;

public class CurrencyCheckButton : MonoBehaviour
{
    public PlayerController playerController; 
    public GameObject imageToShow; 
    public Button currencyCheckButton; 

    private void Start()
    {
       
        currencyCheckButton.onClick.AddListener(CheckCurrency); 

        
        imageToShow.SetActive(false);
    }

    private void CheckCurrency()
    {
        
        if (playerController.currency >= 2000)
        {
            imageToShow.SetActive(true); 
        }
        else
        {
            Debug.Log("Недостаточно валюты!"); 
        }
    }
}