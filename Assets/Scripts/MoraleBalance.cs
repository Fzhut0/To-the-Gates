using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MoraleBalance : MonoBehaviour
{
    [SerializeField] int currentMorale;
    [SerializeField] int startingMorale = 10;

    [SerializeField] TextMeshProUGUI displayMorale;
    [SerializeField] GameObject nodeSpawnAnnoucer;
    public int CurrentMorale { get { return currentMorale; } }

    private void Awake()
    {
        currentMorale = startingMorale;
        UpdateDisplay();
    }

    private void Update()
    {
        AnnouceNode();
    }


    public void IncreaseMorale(int amount)
    {
        currentMorale += Mathf.Abs(amount);
        UpdateDisplay();
    }

    public void DecreaseMorale(int amount)
    {
        currentMorale -= Mathf.Abs(amount);
        UpdateDisplay();
    }

    private void UpdateDisplay()
    {
        displayMorale.text = "Morale:" + currentMorale;
    }

    void AnnouceNode()
    {
        if (currentMorale >= 60)
        {
            nodeSpawnAnnoucer.SetActive(true);
        }
        if (currentMorale >= 100)
        {
            nodeSpawnAnnoucer.SetActive(false);
        }

    }
}
