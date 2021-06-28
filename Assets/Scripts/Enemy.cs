using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] int resourcesReward = 25;
    [SerializeField] int resourcesWithdraw = 50;
    [SerializeField] int moraleReward = 1;

    ResourcesBank bank;
    MoraleBalance morale;


    private void Start()
    {
        bank = FindObjectOfType<ResourcesBank>();
        morale = FindObjectOfType<MoraleBalance>();
    }
    public void RewardResources()
    {
        if (bank == null) { return; }
        bank.Deposit(resourcesReward);

        if (morale == null) { return; }
        morale.IncreaseMorale(moraleReward);
    }

    public void WithdrawResources()
    {
        if (bank == null) { return; }
        bank.Withdraw(resourcesWithdraw);
    }

}
