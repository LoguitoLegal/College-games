using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    [Header("Game")]
    [SerializeField] private int elimitationsToWin;

    [Header("Player")]
    [SerializeField] private int healthPoints;
    [SerializeField] private int enemiesEliminations;

    [Header("UI Things")]
    [SerializeField] private TMP_Text healthText;
    [SerializeField] private TMP_Text eliminationsText;
    [SerializeField] private GameObject endScreen;
    [SerializeField] private TMP_Text endMessage;

    private void Start()
    {
        Time.timeScale = 1f;
        RefreshStatus();
    }
    private void LateUpdate()
    {
        if (VerifyWin())
        {
            OnWin();
        }

        if (VerifyLose())
        {
            OnLose();
        }
    }

    //Win Conditions
    public bool VerifyWin() => enemiesEliminations <= 0;

    public bool VerifyLose() => healthPoints <= 0;

    public void OnWin()
    {
        endMessage.text = "Enemies destroyed. Good Job!";
        endScreen.SetActive(true);
        Time.timeScale = 0f;
    }

    public void OnLose()
    {
        endMessage.text = "You've lost, and all the hope is gone...";
        endMessage.color = Color.red;
        endScreen.SetActive(true);
        Time.timeScale = 0f;
    }

    //Status
    public void ChangeHealth(int hp)
    {
        this.healthPoints += hp;
    }

    public void AddElimination()
    {
        this.enemiesEliminations--;
    }

    public void RefreshStatus()
    {
        this.healthText.text = "" + healthPoints;
        this.eliminationsText.text = "" + enemiesEliminations;
    }

    //Others
    public void LoadLevel(int level)
    {
        SceneManager.LoadScene(level);
    }

    public void CloseGame()
    {
        Application.Quit();
    }
}
