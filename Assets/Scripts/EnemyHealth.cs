using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{

    [SerializeField] int maxHitPoints = 2;
    [SerializeField] int difficultyRamp = 1;

    EnemyMover enemyMover;
    Enemy enemy;

    public int currentHitPoints = 0;

    private void OnEnable()
    {
        currentHitPoints = maxHitPoints;
    }
    private void OnParticleCollision(GameObject other)
    {
        ProcessHit();
    }

    private void Start()
    {
        enemy = GetComponent<Enemy>();


    }

    void ProcessHit()
    {
        currentHitPoints--;

        if (currentHitPoints <= 0)
        {
            gameObject.SetActive(false);
            enemy.enabled = false;
            enemy.RewardResources();
            maxHitPoints += difficultyRamp;

        }
    }
}
