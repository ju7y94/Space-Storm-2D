using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioClip[] rocketDestroy;
    [SerializeField] AudioClip fireShot;
    [SerializeField] AudioClip weaponBonus;
    [SerializeField] AudioClip hitPlayer;
    [SerializeField] AudioClip respawnPlayer;
    [SerializeField] AudioClip healthBonus;
    float defaultLevel = 0.25f;
    AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AudioFireShot()
    {
        audioSource.PlayOneShot(fireShot, defaultLevel);
    }
    public void AudioRocketDestroy()
    {
        audioSource.PlayOneShot(rocketDestroy[Mathf.RoundToInt(Random.Range(0f,1f))], defaultLevel);
    }
    public void AudioWeaponBonus()
    {
        audioSource.PlayOneShot(weaponBonus, 1f);
    }
    public void AudioHealthBonus()
    {
        audioSource.PlayOneShot(healthBonus, 1f);
    }
    public void AudioHitPlayer()
    {
        audioSource.PlayOneShot(hitPlayer, 1f);
    }
    public void AudioRespawnPlayer()
    {
        audioSource.PlayOneShot(respawnPlayer, defaultLevel);
    }
}
