using UnityEngine;

public class SlipHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;

    public HealthBar healthBar; // Reference to the health bar UI   

    public void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth); 
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
        if (currentHealth <= 0)
        {
            Die();
        }
    }
    void Die()
    {
        // Handle slip death (e.g., destroy object, play animation, etc.)
        Debug.Log("Slip has died!");
        gameObject.SetActive(false); // Deactivate the slip object  
    }
}
