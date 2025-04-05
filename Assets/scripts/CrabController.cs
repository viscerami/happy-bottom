using UnityEngine;

public class CrabController : MonoBehaviour
{
    public ShopWindowController shopWindowController; // —сылка на ShopWindowController

    void OnMouseDown() // ќбработка клика на раке-отшельнике
    {
        shopWindowController.OpenShop(); // ќткрываем окно магазина
    }
}
