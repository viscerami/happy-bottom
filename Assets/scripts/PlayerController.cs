using UnityEngine;
using TMPro; // ����������� ������������ ���� ��� TMP

public class PlayerController : MonoBehaviour
{
    public int currency = 0; // ������� ������
    public TextMeshProUGUI currencyText; // TMP ����� ��� ������

    // ����������� ������ ��� ����� �� ��������
    public void ClickOnPlant(int value)
    {
        currency += value;
        UpdateCurrencyUI();
    }

    // ��������� ����� ������ �� ������
    public void UpdateCurrencyUI() // �������� �� public
    {
        currencyText.text = "Currency: " + currency;
    }
}
