using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePlayer : MonoBehaviour
{
    PlayerHealth playerHealth;
    [SerializeField] float damageToPlayer;
    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.tag == "Player")
        {
            playerHealth = collision.gameObject.GetComponent<PlayerHealth>();
            playerHealth.Damage(damageToPlayer);
            EnemyManager.enemyAmount--;
            Destroy(gameObject);
        }
    }
}
