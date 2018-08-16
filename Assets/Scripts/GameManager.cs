using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
    /**
    private static GameManager _instance;

    public static GameManager Instance
    {
        get
        {
            return _instance;
        }
    }
    **/

    public SpawnObject spawnerTwo;
    public SpawnObject spawnerThree;
    public SpawnObject spawnerFour;
    public GameObject gameOver;

    public GameObject controlTwo;
    public GameObject controlThree;
    public GameObject controlFour;

    private static GameObject gameOverPanel;

    private float minWaitTwo = 1.5f;
    private float maxWaitTwo = 2f;

    private float minWaitThree = 1.5f;
    private float maxWaitThree = 2f;

    private float minWaitFour = 1.5f;
    private float maxWaitFour = 3f;

    private bool isSpawningTwo;
    private bool isSpawningThree;
    private bool isSpawningFour;

    private Rigidbody2D rbtwo;
    private Rigidbody2D rbthree;
    private Rigidbody2D rbfour;

    private void Start()
    {
        UnpauseGame();
        isSpawningFour = false;
        isSpawningThree = false;
        isSpawningTwo = false;

        rbtwo = controlTwo.GetComponentInChildren<Rigidbody2D>();
        rbthree = controlThree.GetComponentInChildren<Rigidbody2D>();
        rbfour = controlFour.GetComponentInChildren<Rigidbody2D>();
        rbtwo.isKinematic = true;
        rbthree.isKinematic = true;
        rbfour.isKinematic = true;

        gameOverPanel = gameOver;
    }
    /**
    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(gameObject);
            return;
        } else
        {
            _instance = this;
        }

        DontDestroyOnLoad(gameObject);
    }
    **/



    // Update is called once per frame
    void Update () {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            QuitGame();
        }

        if(!isSpawningFour && ScoreManager.Score > 15)
        {
            rbfour.isKinematic = false;
            float timer = Random.Range(minWaitFour, maxWaitFour);
            Invoke("SpawnFour", timer);
            isSpawningFour = true;
        }
        if(!isSpawningThree && ScoreManager.Score > 10)
        {
            rbthree.isKinematic = false;
            float timer = Random.Range(minWaitThree, maxWaitThree);
            Invoke("SpawnThree", timer);
            isSpawningThree = true;
        }
        if (!isSpawningTwo && ScoreManager.Score > 5)
        {
            rbtwo.isKinematic = false;
            float timer = Random.Range(minWaitTwo, maxWaitTwo);
            Invoke("SpawnTwo", timer);
            isSpawningTwo = true;
        }
	}

    public void QuitGame()
    {
        Application.Quit();
    }


    public void Reload()
    {
        SceneManager.LoadScene("Game");
    }

    public static void PauseGame()
    {
        Time.timeScale = 0;
    }

    public static void UnpauseGame()
    {
        Time.timeScale = 1;
    }
    
    //Game Over Sequence
    public static void TriggerGameOver()
    {
        PauseGame();
        gameOverPanel.SetActive(true);
    }


    //Spawn Scripts
    void SpawnTwo()
    {
        int spawnInd = Random.Range(0, 2);
        float length = Random.Range(1f, 2.5f);
        Vector3 scale = new Vector3(1, length, 1);
        spawnerTwo.Spawn(spawnInd, scale, false);
        isSpawningTwo = false;
    }

    void SpawnThree()
    {
        int spawnInd = Random.Range(0, 2);
        Vector3 scale = new Vector3(1, 1, 1);
        spawnerThree.Spawn(spawnInd, scale, true);
        isSpawningThree = false;
    }

    void SpawnFour()
    {
        Vector3 scale = new Vector3(1, 1, 1);
        spawnerFour.Spawn(0, scale, false);
        isSpawningFour = false;
    }
}
