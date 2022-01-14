using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Scoreboard : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI enemyHealth;
    [SerializeField] TextMeshProUGUI turretRange;



    EnemyHealth enemyHitPoints;
    TargetLocator currentTurretRange;


    private void Start()
    {

    }

    void Update()
    {

        EnemyHitPoints();
        CurrentTurretRange();
    }


    void EnemyHitPoints()
    {
        enemyHitPoints = FindObjectOfType<EnemyHealth>();
        if (enemyHitPoints == true)
        {
            enemyHealth.text = "Enemy HP:" + enemyHitPoints.maxHitPoints;
        }
    }


    void CurrentTurretRange()
    {
        currentTurretRange = FindObjectOfType<TargetLocator>();
        if (currentTurretRange == true)
        {
            turretRange.text = "Turret range:" + currentTurretRange.range;
        }
    }



}

