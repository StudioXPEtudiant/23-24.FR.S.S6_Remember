using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public GameObject player;

    public HealthBar healthBar;

    private void Awake()
    {
        GameObject player = GetComponent<GameObject>();
    }

    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    void Update()
    {
        if(currentHealth <= 0)
        {
            Destroy(player); // Si la vie du joueur tombe à zero, il meurt
        }

        if(Input.GetKeyDown(KeyCode.K)) // pour tester la fonction TakeDamage() en appuyant sur K
        {
            TakeDamage(20);
        }
    }

    void TakeDamage(int damage) // à appeler quand je joueur prend un dégat (par un enemie ou autre)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
    }
}
