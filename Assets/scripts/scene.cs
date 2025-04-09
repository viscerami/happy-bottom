using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public void LoadDialogScene()
    {
        SceneManager.LoadScene("dialog"); // Имя сцены должно совпадать с файлом!
    }
}