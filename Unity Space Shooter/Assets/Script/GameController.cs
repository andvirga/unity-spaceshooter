using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//--Main class of the Game, controls everything
public class GameController : MonoBehaviour
{
    #region Public Variables (Visibles from Unity)

    public GameObject hazard;
    public Vector3 spawnValues;
    public int hazardCount;
    public float spawnWait;
    public float startWait;
    public float waveWait;

    public Text scoreText;
    public Text restartText;
    public Text gameOverText;

    private int score;
    private bool gameOver;
    private bool restart;

    #endregion

    #region Methods

    private IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(startWait);

        while (true)
        {
            for (int i = 0; i < hazardCount; i++)
            {
                var spawnPosition = new Vector3
                {
                    x = Random.Range(-spawnValues.x, spawnValues.x),
                    y = spawnValues.y,
                    z = spawnValues.z
                };
                var spawnRotation = Quaternion.identity;
                Instantiate(hazard, spawnPosition, spawnRotation);
                yield return new WaitForSeconds(spawnWait);
            }
            yield return new WaitForSeconds(waveWait);

            if (gameOver)
            {
                restartText.text = "Press R to restart";
                restart = true;
            }
        }
    }

    // Use this for initialization
    public void Start()
    {
        score = 0;
        gameOver = false;
        restart = false;
        restartText.text = "";
        gameOverText.text = "";

        UpdateScore();
        StartCoroutine(SpawnWaves());
    }

    public void Update()
    {
        if (restart && Input.GetKeyDown(KeyCode.R))
        {
            Application.LoadLevel(Application.loadedLevel);
        }
    }


    public void AddScore(int newScoreValue)
    {
        score += newScoreValue;
        UpdateScore();
    }

    void UpdateScore()
    {
        scoreText.text = "Score: " + score;
    }

    public void GameOver()
    {
        gameOverText.text = "GAME OVER";
        gameOver = true;
    }


    #endregion
}
