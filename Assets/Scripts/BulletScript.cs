using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    [SerializeField] int damageAmount;
    AudioManager audioManager;
    //[SerializeField] AudioManager audioManager;
    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        EnemyScript enemyObject = collision.gameObject.GetComponent<EnemyScript>();
        // if(enemyObject != null)
        // {
        //     enemyObject.DealDamage(damageAmount);
        //     Destroy(gameObject);
        // }
        if(collision.gameObject.tag == "Enemy")
        {
            enemyObject.DealDamage(GetDamageAmount());
            audioManager.AudioRocketDestroy();
            Destroy(gameObject);
        }

    }
    // Start is called before the first frame update
    void Start()
    {
        audioManager = GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int GetDamageAmount()
    {
        return damageAmount;
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
