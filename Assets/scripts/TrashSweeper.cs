using UnityEngine;

public class TrashSweeper : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetMouseButton(0)) // Проверяем, нажата ли левая кнопка мыши
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Collider2D[] colliders = Physics2D.OverlapCircleAll(mousePosition, 0.5f); // Проверяем коллайдеры в радиусе

            foreach (Collider2D collider in colliders)
            {
                if (collider.CompareTag("Trash")) // Убедитесь, что у мусора установлен тег "Trash"
                {
                    Destroy(collider.gameObject); // Удаляем мусор
                }
            }
        }
    }
}
