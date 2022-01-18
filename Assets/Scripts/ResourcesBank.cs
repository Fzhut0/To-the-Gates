using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ResourcesBank : MonoBehaviour
{
    [SerializeField] public int currentBalance;
    [SerializeField] int startingBalance = 150;
    [SerializeField] GameObject gameOver;

    [SerializeField] TextMeshProUGUI displayBalance;

    public int CurrentBalance { get { return currentBalance; } }

    private void Awake()
    {
        currentBalance = startingBalance;
        UpdateDisplay();
    }

    private void Update()
    {
        RestartGame();
    }
    public void Deposit(int amount)
    {
        currentBalance += Mathf.Abs(amount);
        UpdateDisplay();
    }

    public void Withdraw(int amount)
    {
        currentBalance -= Mathf.Abs(amount);
        UpdateDisplay();
    }

    private void UpdateDisplay()
    {
        displayBalance.text = "Resources: " + currentBalance;
    }

    void RestartGame()
    {
        if (currentBalance <= -10)
        {
            gameOver.SetActive(true);
            Time.timeScale = 0f;
        }


    }

}
