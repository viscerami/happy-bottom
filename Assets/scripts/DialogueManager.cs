using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System.Collections;

public class DialogueManager : MonoBehaviour
{
    public GameObject dialoguePanel;
    public TextMeshProUGUI dialogueText;
    public string[] dialogueLines;
    private int currentLineIndex = 0;
    private Coroutine typingCoroutine; // Ссылка на текущую корутину

    private void Start()
    {
        // Изначально панель диалога скрыта
        
    }

    public void StartDialogue()
    {
        dialoguePanel.SetActive(true);
        currentLineIndex = 0;
        ShowNextLine();
    }

    public void ShowNextLine()
    {
        if (currentLineIndex < dialogueLines.Length)
        {
            // Останавливаем предыдущую корутину, если она выполняется
            if (typingCoroutine != null)
            {
                StopCoroutine(typingCoroutine);
            }
            typingCoroutine = StartCoroutine(TypeSentence(dialogueLines[currentLineIndex]));
            currentLineIndex++;
        }
        else
        {
            EndDialogue();
        }
    }

    private IEnumerator TypeSentence(string sentence)
    {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(0.05f);
        }
    }

    private void EndDialogue()
    {
        dialoguePanel.SetActive(false);
        SceneManager.LoadScene("GameScene");
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ShowNextLine();
        }
    }
}

