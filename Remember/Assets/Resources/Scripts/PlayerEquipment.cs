using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEquipment : MonoBehaviour
{
    [SerializeField] private Animator playerAnimator; // L'Animator principal du personnage
    //[SerializeField] public SpriteRenderer weaponSpriteRenderer; // Le SpriteRenderer pour l'arme
    [SerializeField] public SpriteRenderer armorSpriteRenderer; // Le SpriteRenderer pour l'armure

    // Méthode pour équiper une arme
    public void EquipWeapon(Sprite weaponSprite)
    {
        // Vérifie si le sprite d'arme est valide
        //if (weaponSprite != null)
        {
            // Remplace le sprite de l'arme dans le SpriteRenderer
            //weaponSpriteRenderer.sprite = weaponSprite;
            // Ici, tu peux aussi ajouter des logiques spécifiques à l'arme, par exemple, des stats, etc.
        }
        SyncAnimation();
    }

    // Méthode pour équiper une armure
    public void EquipArmor(Sprite armorSprite)
    {
        // Vérifie si le sprite d'armure est valide
        if (armorSprite != null)
        {
            // Remplace le sprite de l'armure dans le SpriteRenderer
            armorSpriteRenderer.sprite = armorSprite;
            // Ici, tu peux aussi ajouter des logiques spécifiques à l'armure, par exemple, des stats, etc.
        }
        SyncAnimation();
    }

    // Synchronisation des animations des layers de l'Animator
    private void SyncAnimation()
    {
        // Récupérer les paramètres d'animation du joueur
        bool isMoving = playerAnimator.GetBool("IsMoving");
        float moveX = playerAnimator.GetFloat("MoveX");
        float moveY = playerAnimator.GetFloat("MoveY");

        // Activer le Armor Layer avec un poids de 1 pour le rendre visible et synchroniser
        playerAnimator.SetLayerWeight(playerAnimator.GetLayerIndex("Armor Layer"), 1);

        // Synchroniser les paramètres avec les layers
        playerAnimator.SetBool("IsMoving", isMoving);
        playerAnimator.SetFloat("MoveX", moveX);
        playerAnimator.SetFloat("MoveY", moveY);

        // Synchroniser l'état actuel de l'animation principale avec l'Armor Layer
        AnimatorStateInfo currentState = playerAnimator.GetCurrentAnimatorStateInfo(0);
        playerAnimator.Play(currentState.shortNameHash, playerAnimator.GetLayerIndex("Armor Layer"), currentState.normalizedTime);
    }

}
