using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoraleBalance : MonoBehaviour
{
    [SerializeField] int currentMorale;
    [SerializeField] int startingMorale = 50;

    public int CurrentMorale { get { return currentMorale; } }

    private void Awake()
    {
        currentMorale = startingMorale;
    }


    public void IncreaseMorale(int amount)
    {
        currentMorale += Mathf.Abs(amount);
    }

    public void DecreaseMorale()
    {

    }
}
