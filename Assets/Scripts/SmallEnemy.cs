using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallEnemy : EnemyScript
{
    // Start is called before the first frame update
    void Start()
    {
        health = 10;
        points = 50;
        Invoke("EnemyDestroy", 25f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
