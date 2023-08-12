using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpreadFireObject : MonoBehaviour
{
    BulletsFire bulletsFire;
    Rigidbody2D rb;
    AudioManager audioManager;
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "Player")
        {
            bulletsFire = other.gameObject.GetComponent<BulletsFire>();
            if(!bulletsFire.GetSpreadShot() && !bulletsFire.GetMultiShot())
            {
                bulletsFire.SetSpreadShot();
                EnemyManager.SubtractWaveWait();
                audioManager.AudioWeaponBonus();
                Destroy(gameObject);
            }
            else if(bulletsFire.GetSpreadShot() && !bulletsFire.GetMultiShot())
            {
                bulletsFire.SetMultiShot();
                bulletsFire.SetSpreadShot();
                EnemyManager.SubtractWaveWait();
                audioManager.AudioWeaponBonus();
                Destroy(gameObject);
            }
            else if(!bulletsFire.GetSpreadShot() && bulletsFire.GetMultiShot())
            {
                TheGameManager.AddMultiplier();
                EnemyManager.SubtractWaveWait();
                audioManager.AudioWeaponBonus();
                Destroy(gameObject);
            }
            else
            {
                audioManager.AudioWeaponBonus();
                Destroy(gameObject);
            }
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
