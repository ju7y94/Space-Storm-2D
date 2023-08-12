using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeBooster : MonoBehaviour
{
    AudioManager audioManager;
    Rigidbody2D rb;
    int lifeBoostAmount = 1;
    float healAmount = 25f;
    float playerCurrentHealth;
    PlayerHealth playerHealth;
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "Player")
        {   
            PlayerHealth playerHealth = other.gameObject.GetComponent<PlayerHealth>();
            if(playerHealth.GetHealth() >= 100)
            {
                TheGameManager.AddLife(lifeBoostAmount);
            }
            else if(playerHealth.GetHealth() >= 100 - healAmount)
            {
                playerHealth.SetMaxHealth();
            }
            else if(playerHealth.GetHealth() < 100 - healAmount)
            {
                playerHealth.DoHeal(healAmount);
            }
            
            EnemyManager.SubtractWaveWait();
            EnemyManager.SubtractSpawnWait();
            audioManager.AudioHealthBonus();
            Destroy(gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        audioManager = GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>();
        Destroy(gameObject, 10f);
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(0f, -2f);
    }
}
