using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.InputSystem; // Currently not being used in this file, implement later for consistency

public enum Damage{
        PlayerHurt = 1, //damage dealt to player when hit by enemy
        SwordDamage = 1 //damage dealt by sword weapon
    }

public class Player : MonoBehaviour {

    [SerializeField] private int maxHealth = 5;
    [SerializeField] private int currentHealth;
    [SerializeField] private HealthBar healthBar;

    private void Start() {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    private void Update() {
        if ( Input.GetKeyDown(KeyCode.Space) ) {
            TakeDamage();
        }

        if ( currentHealth < 0 ) {
            currentHealth = 0;
        }
    }

    private void TakeDamage() {
        currentHealth -= (int)Damage.PlayerHurt;
        
        healthBar.SetHealth(currentHealth);
    }
}