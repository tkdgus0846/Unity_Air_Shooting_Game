using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManagerScript : MonoBehaviour
{
    public static GameManagerScript instance;
    
    public Button pauseButton;

    public GameObject pausePanel;
    public Button resumeButton;
    public Button mainMenuButton;

    public GameObject gameOverPanel;
    public Button restartButton;
    public Button gameOverMainMenuButton;

    public Text coinText;
    public GameObject asteroid;
    public List<GameObject> enemies;
    public float time = 0;
    public float spawnTime = 1;
    public float coin;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        coin = 0;
        coinText.text = coin.ToString();

        pauseButton.onClick.AddListener(PauseAction);
        resumeButton.onClick.AddListener(ResumeAction);
        mainMenuButton.onClick.AddListener(MenuAction);

        restartButton.onClick.AddListener(RestartAction);
        gameOverMainMenuButton.onClick.AddListener(MenuAction);

    }

    void Update()
    {
        time += Time.deltaTime;
        if (time > spawnTime)
        {
            int check = Random.Range(0, 2);
            if(check==0)
            {
                Vector3 spawnPos = new Vector3(9, Random.Range(-4.0f, 4.0f), 0);
                Instantiate(asteroid, spawnPos, Quaternion.identity);
            }
            else
            {
                int type = Random.Range(0, 3);
                Vector3 spawnPos = new Vector3(9, Random.Range(-4.0f, 4.0f), 0);
                Instantiate(enemies[type], spawnPos, Quaternion.identity);
            }
            
            
            time = 0;
        }
         
    }

    void PauseAction()
    {
        Time.timeScale = 0;
        pausePanel.SetActive(true);
    }

    void ResumeAction()
    {
        Time.timeScale = 1;
        pausePanel.SetActive(false);
    }

    void MenuAction()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("MenuScene");
    }

    void RestartAction()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
