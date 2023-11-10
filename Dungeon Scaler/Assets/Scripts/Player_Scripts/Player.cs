using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
            TakeDamage(1);
        }

        if ( currentHealth < 0 ) {
            currentHealth = 0;
        }
    }

    private void TakeDamage(int damage) {
        currentHealth -= damage;
        
        healthBar.SetHealth(currentHealth);
    }
}