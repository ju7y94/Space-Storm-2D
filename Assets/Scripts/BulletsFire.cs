using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletsFire : MonoBehaviour
{
    [SerializeField] float bulletSpeed;
    [SerializeField] Rigidbody2D bullet;
    [SerializeField] GameObject bulletSpawn;
    [Range(0.01f, 0.65f)]
    float autoFireDelay = 0.65f;
    float autoFireTimer = 0f;
    float fireDelay = 0.75f;
    float fireTimer = 0f;
    bool spreadshot = false;
    bool autofire = false;
    bool multishot = false;
    float pressure = 100f;
    bool critical;
    float pressureDecrease = 10f;
    float pressureIncrease = 5f;
    AudioManager audioManager;

    // Start is called before the first frame update
    void Start()
    {
        audioManager = GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(autofire && !critical)
        {
            AutoFire();
        }
        else
        {
            Fire();
        }
        if(pressure >= 15)
        {
            critical = false;
        }
        else if(pressure <= 0)
        {
            critical = true;
        }
    }

    void Fire()
    {
        fireTimer += Time.deltaTime;
        if(Input.GetButtonDown("Fire1") && !TheGameManager.paused && pressure > 0)
        {
            if(fireTimer >= fireDelay)
            { 
                pressure -= 2f;
                
                if(spreadshot)
                {
                    SpreadShot();
                }
                else if(multishot)
                {
                    MultiShot();
                }
                else
                {
                    FireShot();
                }
                fireTimer = 0f;
            }
        }

        if(pressure < 100 && !Input.GetButtonDown("Fire1"))
        {   
            pressure += pressureIncrease * Time.deltaTime;
        }
    }

    void AutoFire()
    {
        autoFireTimer += Time.deltaTime;
        
        if(Input.GetButton("Fire1") && !TheGameManager.paused)
        {
                pressure -= pressureDecrease * Time.deltaTime;
                if(autoFireTimer >= autoFireDelay)
                {   
                    if(spreadshot)
                    {
                        SpreadShot();
                    }
                    else if(multishot)
                    {
                        MultiShot();
                    }
                    else
                    {
                        FireShot();
                    }
                    autoFireTimer = 0f;
                }
        }
        if(pressure < 100 && !Input.GetButton("Fire1"))
        {   
            pressure += pressureIncrease * Time.deltaTime;
        }
    }

    void FireShot()
    {
        Rigidbody2D shot;
        shot = Instantiate(bullet, transform.position + new Vector3(0f, 0.6f, 0f), transform.rotation);
        shot.velocity = new Vector3(0f, 1.0f, 0f) * bulletSpeed;
        audioManager.AudioFireShot();
    }

    void SpreadShot()
    {
        Rigidbody2D midShot;
        Rigidbody2D leftShot;
        Rigidbody2D rightShot;

        midShot = Instantiate(bullet, transform.position + new Vector3(0f, 0.6f, 0f), transform.rotation);
        leftShot = Instantiate(bullet, transform.position + new Vector3(-0.2f, -0.25f, 0f), Quaternion.Euler(0f,0f,25f));
        rightShot = Instantiate(bullet, transform.position + new Vector3(0.2f, -0.25f, 0f), Quaternion.Euler(0f,0f,-25f));
        midShot.velocity = new Vector3(0f, 1.0f, 0f) * bulletSpeed;
        leftShot.velocity = new Vector3(-0.5f, 1.0f, 0f) * bulletSpeed;
        rightShot.velocity = new Vector3(0.5f, 1.0f, 0f) * bulletSpeed;
        audioManager.AudioFireShot();
    }

    void MultiShot()
    {
        Rigidbody2D midShot;
        Rigidbody2D left1Shot;
        Rigidbody2D right1Shot;
        Rigidbody2D left2Shot;
        Rigidbody2D right2Shot;

        midShot = Instantiate(bullet, transform.position + new Vector3(0f, 0.6f, 0f), transform.rotation);
        left1Shot = Instantiate(bullet, transform.position + new Vector3(-0.2f, -0.25f, 0f), Quaternion.Euler(0f,0f,25f));
        right1Shot = Instantiate(bullet, transform.position + new Vector3(0.2f, -0.25f, 0f), Quaternion.Euler(0f,0f,-25f));
        left2Shot = Instantiate(bullet, transform.position + new Vector3(-0.1f, 0.25f, 0f), Quaternion.Euler(0f,0f,15f));
        right2Shot = Instantiate(bullet, transform.position + new Vector3(0.1f, 0.25f, 0f), Quaternion.Euler(0f,0f,-15f));
        midShot.velocity = new Vector3(0f, 1.0f, 0f) * bulletSpeed;
        left1Shot.velocity = new Vector3(-0.5f, 1.0f, 0f) * bulletSpeed;
        right1Shot.velocity = new Vector3(0.5f, 1.0f, 0f) * bulletSpeed;
        left2Shot.velocity = new Vector3(-0.25f, 1.0f, 0f) * bulletSpeed;
        right2Shot.velocity = new Vector3(0.25f, 1.0f, 0f) * bulletSpeed;
        audioManager.AudioFireShot();
    }

    public bool GetMultiShot()
    {
        return multishot;
    }
    public void SetMultiShot()
    {
        multishot = !multishot;
    }

    public bool GetSpreadShot()
    {
        return spreadshot;
    }
    public void SetSpreadShot()
    {
        spreadshot = !spreadshot;
    }

    public bool GetAutoFire()
    {
        return autofire;
    }
    public void SetAutoFire()
    {
        autofire = !autofire;
    }
    public float GetAutoFireDelay()
    {
        return autoFireDelay;
    }
    public void SubtractAutoDelay()
    {
        autoFireDelay -= autoFireDelay/20;
    }
    public float GetPressure()
    {
        return pressure;
    }
    public void AddPressureDecrease()
    {
        pressureDecrease += pressureDecrease/20;
    }
}
