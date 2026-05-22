using UnityEngine;

public class SlipHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;

    [SerializeField] public int _damageAmount; // Amount of damage to apply when colliding with an obstacle
    [SerializeField] private GameController gameController; // Reference to the GameController script

    public HealthBar healthBar; // Reference to the health bar UI  

    public void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth); 
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacles"))
        {
            TakeDamage(_damageAmount);
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
        Debug.Log("Player took damage. Current health: " + currentHealth);
        if (currentHealth == 0)
        {
           gameController.Die();
          
        }
    }
}
