using UnityEngine;

public class CrabController : MonoBehaviour
{
    public ShopWindowController shopWindowController; 

    void OnMouseDown() 
    {
        shopWindowController.OpenShop(); 
    }
}
