using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI; 
public class PlantButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject plantImage; 
    private Image buttonImage; 

    private void Start()
    {
        buttonImage = GetComponent<Image>(); 
    }

    
    public void OnPointerEnter(PointerEventData eventData)
    {
        plantImage.SetActive(true); 
    }

   
    public void OnPointerExit(PointerEventData eventData)
    {
        plantImage.SetActive(false); 
    }

   
    public void SetIconAvailability(bool isAvailable)
    {
        Color color = buttonImage.color;
        color.a = isAvailable ? 1f : 0.5f; 
        buttonImage.color = color;
    }
}
