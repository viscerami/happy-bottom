using UnityEngine;

public class TrashSweeper : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetMouseButton(0)) // ���������, ������ �� ����� ������ ����
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Collider2D[] colliders = Physics2D.OverlapCircleAll(mousePosition, 0.5f); // ��������� ���������� � �������

            foreach (Collider2D collider in colliders)
            {
                if (collider.CompareTag("Trash")) // ���������, ��� � ������ ���������� ��� "Trash"
                {
                    Destroy(collider.gameObject); // ������� �����
                }
            }
        }
    }
}
