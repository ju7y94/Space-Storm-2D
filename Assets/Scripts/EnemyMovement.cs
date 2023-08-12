using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    Rigidbody2D enemyRB;
    // Start is called before the first frame update
    void Start()
    {
        enemyRB = GetComponent<Rigidbody2D>();
        enemyRB.velocity = new Vector2(Random.Range(-0.25f, 0.25f) * moveSpeed, -1f * moveSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
