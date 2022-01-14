using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ResourcesBank : MonoBehaviour
{
    [SerializeField] int currentBalance;
    [SerializeField] int startingBalance = 150;

    [SerializeField] TextMeshProUGUI displayBalance;

    public int CurrentBalance { get { return currentBalance; } }

    private void Awake()
    {
        currentBalance = startingBalance;
        UpdateDisplay();
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

}
