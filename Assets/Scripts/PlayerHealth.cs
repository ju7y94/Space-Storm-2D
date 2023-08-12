using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    float currentHealth;
    float maxHealth = 100f;
    AudioManager audioManager;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        audioManager = GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>();
    }

    // Update is called once per frame
    void Update()
    {
    
    }

    public void Damage(float damage)
    {
        currentHealth -= damage;
        audioManager.AudioHitPlayer();
        if (currentHealth <= 0)
        {
            Destroy(gameObject);
            TheGameManager.PlayerDeath();
        }
    }

    public void DoHeal(float heal)
    {
        currentHealth += heal;
    }
    public float GetHealth()
    {
        return currentHealth;
    }
    public void SetMaxHealth()
    {
        currentHealth = maxHealth;
    }
}
