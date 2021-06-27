using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{

    [SerializeField] int maxHitPoints = 2;
    [SerializeField] int difficultyRamp = 1;

    int currentHitPoints = 0;

    private void Awake()
    {
        currentHitPoints = maxHitPoints;
    }
    private void OnParticleCollision(GameObject other)
    {
        ProcessHit();
    }

    void ProcessHit()
    {
        currentHitPoints--;
        if (currentHitPoints <= 0)
        {
            gameObject.SetActive(false);
            maxHitPoints += difficultyRamp;
        }
    }
}
