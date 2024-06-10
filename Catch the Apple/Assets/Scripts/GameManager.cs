using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using TMPro;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject apple;
    [SerializeField] private GameObject goldenApple;
    [SerializeField] private GameObject rotApple;
    [SerializeField] private int pointsToWin;
    //Spawn Variables
    private float spawnTime;
    [SerializeField] private float spawnCooldown;
    //Score and Health Variables (two for text in Canvas, two for the float valuables)
    private TMP_Text score;
    private TMP_Text health;
    [SerializeField] private int healthPoints;
    [SerializeField] private int points;
    //Win and Lose text in Canvas
    [SerializeField] private TMP_Text result;
    //Panel
    [SerializeField] GameObject panel;
    //Audio
    [SerializeField] private AudioSource audioPlay;
    [SerializeField] private AudioClip healthLose, earnPoint1, earnPoint2, loseGame, winGame;

    private void Start()
    {
        score = GameObject.Find("Score").GetComponent<TMP_Text>();
        health = GameObject.Find("Life").GetComponent <TMP_Text>();
        RefreshStatus();
        Time.timeScale = 1f;
    }
    void Update()
    {
        spawnTime += Time.deltaTime;
        if (spawnTime >= spawnCooldown)
        {
            Spawn();
            spawnTime = 0;
        }

        if (VerifyWin())
        {
            OnWin();
        }
        if (VerifyLose())
        {
            OnLose();
        }
    }

    //Cool Methods
    private void Spawn()
    {
        Vector3 spawnPosition = new Vector3();
        spawnPosition.y = 7.55f;
        spawnPosition.x = Random.Range(-19f, 19f);
        //50% de chance de ser uma maçã especial
        if (Random.Range(0, 100) < 50)
        {
            if (Random.Range(0, 100) < 50)
            {
                //Há 50% de chance dessa maçã ser dourada
                Instantiate(goldenApple, spawnPosition, Quaternion.identity);
            }
            else
            {
                //Há 50% de chance dessa maçã ser podre
                Instantiate(rotApple, spawnPosition, Quaternion.identity);
            }
        }
        else
        {
            Instantiate(apple, spawnPosition, Quaternion.identity);
        }
    }
    
    public void ResetLevel()
    {
        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
        SceneManager.LoadScene(0);
    }

    //Win and Lose Methods
    private bool VerifyWin()
    {
        if (points >= pointsToWin)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private bool VerifyLose()
    {
        if (healthPoints <= 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private void OnWin()
    {
        Time.timeScale = 0f;
        result.text = "Victory! Congratulations";
        result.color = Color.yellow;
        panel.SetActive(true);
        audioPlay.clip = winGame;
        audioPlay.Play();
        this.points = pointsToWin - 1;
        this.healthPoints = 3;
    }

    private void OnLose()
    {
        Time.timeScale = 0f;
        result.text = "Defeat! Better luck next time";
        result.color = Color.red;
        panel.SetActive(true);
        audioPlay.clip = loseGame;
        audioPlay.Play();
        this.points = pointsToWin - 1;
        this.healthPoints = 3;
    }

    //Earn points and lose health
    public void EarnPoint()
    {
        this.points++;
        RefreshStatus();
        audioPlay.clip = earnPoint1;
        audioPlay.Play();
    }

    public void EarnTwoPoints()
    {
        this.points += 2;
        audioPlay.clip = earnPoint2;
        if (this.healthPoints < 5)
        {
            this.healthPoints++;
        }
        RefreshStatus();
        audioPlay.Play();
    }

    public void LoseHealth()
    {
        this.healthPoints--;
        RefreshStatus();
        audioPlay.clip = healthLose;
        audioPlay.Play();
    }

    private void RefreshStatus()
    {
        health.text = "Health: " + healthPoints.ToString() + "/5";
        score.text = "Score: " + points.ToString() + "/" + pointsToWin;
    }
}
