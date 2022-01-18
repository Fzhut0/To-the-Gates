using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class MoraleBalance : MonoBehaviour
{
    [SerializeField] int currentMorale;
    [SerializeField] int startingMorale = 10;
    [SerializeField] int winCondition = 300;

    [SerializeField] TextMeshProUGUI displayMorale;
    [SerializeField] GameObject nodeSpawnAnnoucer;
    [SerializeField] GameObject winPanel;
    public int CurrentMorale { get { return currentMorale; } }

    [SerializeField] int nodeSpawn;

    private void Awake()
    {
        currentMorale = startingMorale;
        UpdateDisplay();
    }

    private void Update()
    {
        AnnouceNode();
        LevelWin();
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
        if (currentMorale >= nodeSpawn)
        {
            nodeSpawnAnnoucer.SetActive(true);
        }
        if (currentMorale >= 100)
        {
            nodeSpawnAnnoucer.SetActive(false);
        }
    }

    void LevelWin()
    {
        if (winCondition == currentMorale)
        {
            winPanel.SetActive(true);

            Invoke("WinLevelSwitch", 5f);

        }
    }

    void WinLevelSwitch()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);

    }
}
