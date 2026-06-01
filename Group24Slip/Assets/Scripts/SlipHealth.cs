using System;
using System.Collections;
using UnityEngine;

public class SlipHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;

    [SerializeField] public int _damageAmount; // Amount of damage to apply when colliding with an obstacle
    [SerializeField] private GameController gameController; // Reference to the GameController script

    public HealthBar healthBar; // Reference to the health bar UI  

    [SerializeField]private Animator animator;
    public static event Action onPlayerDeath; // Event to notify when the player dies
    public void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth); 
        animator = GetComponent<Animator>();
        
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacles"))
        { 

            if (animator != null) 
            { 
                animator.SetTrigger("hitTrigger");
            }
            
            TakeDamage(_damageAmount);
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        SFXManager.Play("Hit Effects");
        healthBar.SetHealth(currentHealth);
        if (currentHealth == 0)
        {
           gameController.Die();
           onPlayerDeath.Invoke(); // Invoke the player death event
        }
    }


}
