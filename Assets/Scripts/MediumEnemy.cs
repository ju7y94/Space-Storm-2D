using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MediumEnemy : EnemyScript
{
    [SerializeField] GameObject[] bonusWeapon;
    // Start is called before the first frame update
    void Start()
    {
        health = 15;
        points = 100;
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
            if(randomInt < 15)
            {
                Instantiate(bonusWeapon[Mathf.RoundToInt(Random.Range(0f,1f))], transform.position, Quaternion.Euler(0, 0, 90));
            }
        }
    }
}
