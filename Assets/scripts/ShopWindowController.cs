using UnityEngine;
using UnityEngine.UI; 
using TMPro; 

public class ShopWindowController : MonoBehaviour
{
    public GameObject shopPanel; 
    public ShopController shopController; 
    public Image[] plantIcons; 

    private void Start()
    {
        shopPanel.SetActive(false); 
        UpdatePlantIcons(); 
    }

    public void OpenShop()
    {
        shopPanel.SetActive(true); 
        UpdatePlantIcons(); 
    }

    public void CloseShop()
    {
        shopPanel.SetActive(false); 
    }

    private void UpdatePlantIcons()
    {
        for (int i = 0; i < shopController.availablePlants.Length; i++)
        {
            if (i < plantIcons.Length)
            {
                plantIcons[i].color = shopController.availablePlants[i].isUnlocked ? Color.white : Color.gray; 
            }
        }
    }

    public void BuyPlant(int plantIndex)
    {
        shopController.BuyPlant(plantIndex); 
        CloseShop(); 
    }
}
