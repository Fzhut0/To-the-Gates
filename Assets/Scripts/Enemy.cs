using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] int resourcesReward = 25;
    [SerializeField] int resourcesWithdraw = 50;

    ResourcesBank bank;


    private void Start()
    {
        bank = FindObjectOfType<ResourcesBank>();
    }
    public void RewardResources()
    {
        if (bank == null) { return; }
        bank.Deposit(resourcesReward);
    }

    public void WithdrawResources()
    {
        if (bank == null) { return; }
        bank.Withdraw(resourcesWithdraw);
    }

}
