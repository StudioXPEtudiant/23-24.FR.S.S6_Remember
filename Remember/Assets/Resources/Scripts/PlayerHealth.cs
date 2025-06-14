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
            GameOver();
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

    void GameOver()
    {
        //Time.timeScale = 0f; // Met le jeu en pause
        Debug.Log("Game Over !");

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false; // Stoppe la scène 'game' si le joueur n'a plus de pv. Plus tard, mettre le jeu en pose.
#endif
        // a ajouter plus tard un écran de game over
    }
}
