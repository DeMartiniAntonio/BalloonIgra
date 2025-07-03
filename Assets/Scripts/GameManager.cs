using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    
    [SerializeField] private Balloon balloonPrefab;
    [SerializeField] private Transform[] spawnPoints;
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private TMP_Text livePointsText;
    [SerializeField] private TMP_Text loseText;
    [SerializeField] private float timeInterval = 2f;
    [SerializeField] private float difficultyMultiplier = 0.9f;
    [SerializeField] private GameObject panel;   
    [SerializeField] private GameObject mainMenuPanel;   
    [SerializeField] private GameObject pausePanel;   
    public int lives = 5;
    private int score;
    private float multipliedTime;
    
    private void Awake()
    {
        if (!Instance) Instance = this;
        scoreText.gameObject.SetActive(false);
        livePointsText.gameObject.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !panel.activeInHierarchy && !mainMenuPanel.activeInHierarchy) {
            Pause();
            
        }
    }
    public void PlayGame()
    {
        multipliedTime = timeInterval;
        lives = 5;
        score = 0;
        scoreText.text = $"Score: {score}";
        livePointsText.text = $"LIFE: {lives}";
        scoreText.gameObject.SetActive(true);
        livePointsText.gameObject.SetActive(true);
        StartCoroutine(BalloonSpawning());
    }

    private IEnumerator BalloonSpawning()
    {
        multipliedTime *= difficultyMultiplier;
        float timeValue = Mathf.Max(multipliedTime, 0.6f);
        
        yield return new WaitForSeconds(timeValue);
        
        BalloonSpawnPoint();

        StartCoroutine(BalloonSpawning());
    }

    public void RemoveLife()
    {
        lives--;
        livePointsText.text = $"LIFE {lives}";
        LoseGame();
    }

    private void LoseGame()
    {
        if (lives == 0)
        {
            StopAllCoroutines();
            panel.SetActive(true);
            loseText.text = $"You popped {score} balloons";
            scoreText.gameObject.SetActive(false);
            livePointsText.gameObject.SetActive(false);
        }
    }
    
    private Transform RandomSpawnPoint()
    {
        int random = RandomGeneratedNumber.RandomNumber(spawnPoints.Length);
        return spawnPoints[random];
    }

    private void BalloonSpawnPoint()
    {
        Balloon balloonClone = Instantiate(balloonPrefab, RandomSpawnPoint().position, Quaternion.identity);
        balloonClone.ChangeMaterial();
    }

    public void IncreaseScore()
    {
        score++;
        scoreText.text = $"Score: {score}";
    }
    private void Pause() {

        if (Time.timeScale == 1)
        {
            Time.timeScale = 0f;
            pausePanel.gameObject.SetActive(true);

        }
        else if (Time.timeScale == 0) {
            Time.timeScale = 1f;
            pausePanel.gameObject.SetActive(false);

        }
    }
}