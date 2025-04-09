using UnityEngine;

public class Plant : MonoBehaviour
{
    public int currencyValue = 1; // ������� ������ ���� ��� ��������
    public Sprite seedSprite; // ������ ��� �������
    public Sprite sproutSprite; // ������ ��� ������
    public Sprite adultPlantSprite; // ������ ��� ��������� ��������
    public AudioClip clickSound; // ���� ������
    private AudioSource audioSource; // ������ �� AudioSource

    private PlayerController playerController;
    private SpriteRenderer spriteRenderer; // ��������� SpriteRenderer ��� ��������� �������

    private int growthStage = 0; // ������� ������ ����� (0 - �������, 1 - ������, 2 - �������� ��������)
    private int clickCount = 0; // ������� ������

    public bool isAvailable = false; // �������� �� �������� ��� �������
    public bool isUnlocked = false; // �������� �� �������� ��� ������� (��������������)

    public int purchaseCost = 10; // ��������� ������� ��������

    void Start()
    {
        playerController = FindObjectOfType<PlayerController>(); // ������� PlayerController
        spriteRenderer = GetComponent<SpriteRenderer>(); // �������� ��������� SpriteRenderer
        audioSource = gameObject.AddComponent<AudioSource>(); // ��������� ��������� AudioSource
        audioSource.clip = clickSound; // ������������� �������� ����
        spriteRenderer.sprite = seedSprite; // ������������� ������ �������
    }

    void OnMouseDown() // ��������� ����� �� ��������
    {
        audioSource.Play(); // ������������� ���� ��� �����
        playerController.ClickOnPlant(currencyValue);
        clickCount++; // ����������� ������� ������

        // ���������, �������� �� �� ��������� ������ �����
        if (clickCount >= 25)
        {
            GrowPlant();
            clickCount = 0; // ���������� ������� ������
        }
    }

    private void GrowPlant()
    {
        growthStage++; // ��������� � ��������� ������ �����

        // �������� ������� ��� �������� � ����������� �� ������ �����
        switch (growthStage)
        {
            case 1:
                spriteRenderer.sprite = sproutSprite; // ������������� ������ ������
                Debug.Log("�������� ������� � ������!");
                break;
            case 2:
                spriteRenderer.sprite = adultPlantSprite; // ������������� ������ ��������� ��������
                isAvailable = true; // ������ �������� �������� ��� �������
                isUnlocked = true; // ������������ ��������
                Debug.Log("�������� ������� � �������� ��������!");

                // ������������ ��������� �������� � ��������
                ShopController shopController = FindObjectOfType<ShopController>();
                if (shopController != null)
                {
                    shopController.UnlockNextPlant(FindPlantIndex());
                }
                break;
            default:
                Debug.Log("�������� �������� ������������ ������ �����.");
                break;
        }
    }

    private int FindPlantIndex()
    {
        // ������� ������ �������� �������� � ������� availablePlants
        ShopController shopController = FindObjectOfType<ShopController>();
        for (int i = 0; i < shopController.availablePlants.Length; i++)
        {
            if (shopController.availablePlants[i] == this)
            {
                return i; // ���������� ������ �������� ��������
            }
        }
        return -1; // ���� �� �������, ���������� -1
    }
}
