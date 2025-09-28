
using UnityEngine;
using UnityEngine.UI;
using TMPro; 

public class NPCDiologue : MonoBehaviour
{
    public GameObject dialoguePanel; 
    public TextMeshProUGUI dialogueText; 
    public Button nextButton; 
    public string[] dialogueLines; 
    private int currentLine = 0; 
    private bool isPlayerInRange = false; 

    void Start()
    {
        
        dialoguePanel.SetActive(false);
        
        nextButton.onClick.AddListener(ShowNextLine);
    }

    void Update()
    {
        
        if (isPlayerInRange && Input.GetKeyDown(KeyCode.E))
        {
            StartDialogue();
        }
    }

    void StartDialogue()
    {
       
        currentLine = 0;
        dialoguePanel.SetActive(true);
        ShowNextLine();
    }

    void ShowNextLine()
    {
        if (currentLine < dialogueLines.Length)
        {
           
            dialogueText.text = dialogueLines[currentLine];
            currentLine++;
        }
        else
        {
           
            dialoguePanel.SetActive(false);
        }
    }

    
    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = true;
            Debug.Log("Игрок в зоне NPC. Нажми E для диалога.");
        }
    }

    
    private void OnTriggerExit2D(Collider2D other) 
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = false;
            dialoguePanel.SetActive(false); 
            Debug.Log("Игрок покинул зону NPC.");
        }
    }
}