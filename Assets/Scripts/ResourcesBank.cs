using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourcesBank : MonoBehaviour
{
    [SerializeField] int currentBalance;
    [SerializeField] int startingBalance = 150;

    public int CurrentBalance { get { return currentBalance; } }

    private void Awake()
    {
        currentBalance = startingBalance;
    }


    public void Deposit(int amount)
    {
        currentBalance += Mathf.Abs(amount);
    }

    public void Withdraw(int amount)
    {
        currentBalance -= Mathf.Abs(amount);
    }
}
