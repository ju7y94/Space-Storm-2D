using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigEnemy : EnemyScript
{
    [SerializeField] GameObject bonusHeart;
    // Start is called before the first frame update
    void Start()
    {
        health = 25;
        points = 200;
        Invoke("EnemyDestroy", 25f);
        randomInt = Mathf.RoundToInt(Random.Range(0f, 100f));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void DealDamage(int damageAmount)
    {
        health -= damageAmount;
        if(health <= 0)
        {
            TheGameManager.UpdatePoints(points);
            Destroy(gameObject);
            EnemyManager.enemyAmount--;
            if(randomInt == 77)
            {
                Instantiate(bonusHeart, transform.position, Quaternion.identity);
            }
        }
    }
}
