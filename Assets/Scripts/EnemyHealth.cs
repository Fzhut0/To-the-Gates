using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{

    [SerializeField] int maxHitPoints = 2;
    [SerializeField] int difficultyRamp = 1;

    Enemy enemy;

    int currentHitPoints = 0;

    private void Awake()
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
            enemy.RewardResources();
            maxHitPoints += difficultyRamp;

        }
    }
}
