using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] int resourcesReward = 25;
    [SerializeField] int resourcesWithdraw = 50;
    [SerializeField] int moraleReward = 1;
    [SerializeField] int moraleDecrease = 5;

    ResourcesBank bank;
    MoraleBalance morale;


    private void Start()
    {
        bank = FindObjectOfType<ResourcesBank>();
        morale = FindObjectOfType<MoraleBalance>();
    }
    public void RewardResources()
    {
        if (bank == null || morale == null) { return; }
        bank.Deposit(resourcesReward);
        morale.IncreaseMorale(moraleReward);
    }

    public void WithdrawResources()
    {
        if (bank == null || morale == null) { return; }
        bank.Withdraw(resourcesWithdraw);
        morale.DecreaseMorale(moraleDecrease);
    }



}
