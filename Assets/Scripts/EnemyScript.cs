using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    protected int health;
    protected int points;
    protected int randomInt;
    
    // Start is called before the first frame update
    void Start()
    { 
        Invoke("EnemyDestroy", 25f);
        print(randomInt);
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public virtual void DealDamage(int damageAmount)
    {
        health -= damageAmount;
        if(health <= 0)
        {
            TheGameManager.UpdatePoints(points);
            Destroy(gameObject);
            EnemyManager.enemyAmount--;
        }
    }

    protected void EnemyDestroy()
    {
        Destroy(gameObject);
        EnemyManager.enemyAmount--;
    }
}
