using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPCController : MonoBehaviour
{
    [Header("Dialogue Settings")]
    public List<string> dialogues; // Liste des dialogues
    private int dialogueIndex = 0;

    [Header("PNJ Settings")]
    public float returnToBaseDelay = 3f; // Délai avant retour à la position initale
    public float interactionRange = 2f; // Distance d'interaction
    private Transform player;
    public bool isInteracting = false;
    private Animator animator;

    // Variable pour gérer la direction
    private float PlayerPosX = 0;
    private float PlayerPosY = -1;

    [Header("UI Elements")]
    public GameObject dialogueBox;
    public Text dialogueText;

    void Start()
    {
        animator = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player").transform;

        // S'assurer que le PNJ commence dans la bonne direction
        SetNPCAnimation(PlayerPosX, PlayerPosY);

        // Cacher le dialogue au début
        dialogueBox.SetActive(false);
    }

    void Update()
    {
        if (!isInteracting && Input.GetKeyDown(KeyCode.E) && IsPlayerClose())
        {
            Interact();
        }


        if (isInteracting && Input.GetKeyDown(KeyCode.Space)) // Espace pour faire avancer le dialogue
        {
            ShowNextDialogue();
        }
    }

    bool IsPlayerClose()
    {
        return Vector2.Distance(player.position, transform.position) <= interactionRange;
    }

    public void Interact()
    {
        if (!isInteracting)
        {
            isInteracting = true;
            dialogueIndex = 0;
            dialogueBox.SetActive(true);
        }

        // Met à jour la direction du PNJ en fonction du joueur
        UpdateNPCDirection();
        ShowNextDialogue();
    }

    void ShowNextDialogue()
    {
        if(dialogueIndex < dialogues.Count)
        {
            dialogueText.text = dialogues[dialogueIndex];
            dialogueIndex++;
        }
        else
        {
            EndDialogue();
        }
    }

    void EndDialogue()
    {
        isInteracting = false;
        dialogueBox.SetActive(false);

        if(isInteracting == false)
        {
            StartCoroutine(ReturnToBaseDirection());
        }
    }

    void UpdateNPCDirection()
    {
        Vector2 directionToPlayer = (player.position - transform.position).normalized;
        PlayerPosX = Mathf.Clamp(directionToPlayer.x, -1f, 1f);
        PlayerPosY = Mathf.Clamp(directionToPlayer.y, -1f, 1f);
        SetNPCAnimation(PlayerPosX, PlayerPosY);
    }

    void SetNPCAnimation(float x, float y)
    {
        animator.SetFloat("PlayerPosX", x);
        animator.SetFloat("PlayerPosY", y);
    }

    IEnumerator ReturnToBaseDirection()
    {
        yield return new WaitForSeconds(returnToBaseDelay);
        PlayerPosX = 0;
        PlayerPosY = -1;
        SetNPCAnimation(PlayerPosX, PlayerPosY);
    }
}
