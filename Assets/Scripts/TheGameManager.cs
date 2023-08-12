using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TheGameManager : MonoBehaviour
{
    static public int score;
    public Text totalPoints;
    public Text multiplierText;
    public Text livesText;
    public static TheGameManager tgm;
    static public Vector2 spawnLocation;
    [SerializeField] GameObject playerPrefab;
    [SerializeField] Image healthBar, pressureBarHolder, pressureBar, autofireImage, spreadshotImage;
    GameObject playerInstance;
    static public int multiplier = 1;
    public static bool playerAlive;
    static int lives;
    AudioManager audioManager;
    BulletsFire bulletsFire;

    [SerializeField] GameObject pausePanel, gameOverPanel;
    public static bool paused;
    public static bool gameOver;
    // Start is called before the first frame update
    void Start()
    {
        tgm = this;
        paused = false;
        gameOver = false;
        Time.timeScale = 1f;
        tgm.gameOverPanel.gameObject.SetActive(false);
        audioManager = GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>();
        lives = 3;
        score = 0;
        UpdatePoints(0);
        tgm.Invoke("PlacePlayer", 2f);
        playerAlive = true;
        tgm.multiplierText.text = "x " + multiplier.ToString();
        tgm.livesText.text = lives.ToString();
        
    }

    // Update is called once per frame
    void Update()
    {
        //
        if (Input.GetKeyDown(KeyCode.Escape) && !gameOver)
        {
            paused = !paused;
            if (paused)
            {
                tgm.pausePanel.SetActive(true);
                Time.timeScale = 0f;
            }
            else if(!paused)
            {
                tgm.pausePanel.SetActive(false);
                Time.timeScale = 1f;
            }
        }
        if (!paused)
        {
            Time.timeScale = 1f;
        }

        UpdateUI();
    }

    void UpdateUI()
    {
        tgm.livesText.text = lives.ToString();
        tgm.multiplierText.text = "x " + multiplier.ToString();
        if(playerInstance != null && playerAlive)
        {
            float pressure = playerInstance.GetComponent<BulletsFire>().GetPressure();
            tgm.pressureBar.fillAmount = pressure / 100f;
            float currentPlayerHealth = playerInstance.GetComponent<PlayerHealth>().GetHealth();
            tgm.healthBar.fillAmount = currentPlayerHealth / 100f;
            bool spreadshot, autofire, multishot;
            autofire = playerInstance.GetComponent<BulletsFire>().GetAutoFire();
            spreadshot = playerInstance.GetComponent<BulletsFire>().GetSpreadShot();
            multishot = playerInstance.GetComponent<BulletsFire>().GetMultiShot();
            if(autofire)
            {
                tgm.autofireImage.color = new Color(autofireImage.color.r, autofireImage.color.g, autofireImage.color.b, 1f);
                // tgm.pressureBarHolder.color = new Color(pressureBarHolder.color.r, pressureBarHolder.color.g, pressureBarHolder.color.b, 1f);
                // tgm.pressureBar.color = new Color(pressureBar.color.r, pressureBar.color.g, pressureBar.color.b, 1f);
            }
            else if(!autofire)
            {
                tgm.autofireImage.color = new Color(autofireImage.color.r, autofireImage.color.g, autofireImage.color.b, 0.25f);
                // tgm.pressureBarHolder.color = new Color(pressureBarHolder.color.r, pressureBarHolder.color.g, pressureBarHolder.color.b, 0.25f);
                // tgm.pressureBar.color = new Color(pressureBar.color.r, pressureBar.color.g, pressureBar.color.b, 0.15f);
            }
            if(spreadshot || multishot)
            {
                tgm.spreadshotImage.color = new Color(spreadshotImage.color.r, spreadshotImage.color.g, spreadshotImage.color.b, 1f);
            }
            else if(!spreadshot || !multishot)
            {
                tgm.spreadshotImage.color = new Color(spreadshotImage.color.r, spreadshotImage.color.g, spreadshotImage.color.b, 0.25f);
            }
        }
        else if(playerInstance == null && !playerAlive)
        {
            tgm.pressureBar.fillAmount = 0f;
            tgm.healthBar.fillAmount = 0f;
        }

    }

    public void Unpause()
    {
        paused = false;
        tgm.pausePanel.SetActive(false);
        Time.timeScale = 1f;
    }

    static public void PlayerDeath()
    {
        lives--;
        playerAlive = false;
        if(lives > 0)
        {
            
            multiplier = 1;
            gameOver = false;
            tgm.Invoke("PlacePlayer", 2f);
        }
        else if(lives <= 0)
        {
            Time.timeScale = 0f;
            tgm.gameOverPanel.gameObject.SetActive(true);
            gameOver = true;
        }
    }

    void PlacePlayer()
    {
        spawnLocation = new Vector2(Random.Range(-8.0f, 8.0f), -3.86f);
        playerInstance = Instantiate(playerPrefab, spawnLocation, Quaternion.identity);
        audioManager.AudioRespawnPlayer();
        playerAlive = true;
    }

    static public void UpdatePoints(int points)
    {
        score += points * multiplier;
        tgm.totalPoints.text = score.ToString();
    }
    
    public static void AddMultiplier()
    {
        multiplier++;
        tgm.multiplierText.text = multiplier.ToString();
    }

    public static void AddLife(int i)
    {
        lives += i;
    }
}
