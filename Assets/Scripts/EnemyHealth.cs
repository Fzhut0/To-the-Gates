using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{

    [SerializeField] int maxHitPoints = 2;

    int currentHitPoints = 0;
    // add rampupdifficulty

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
            // add rampup difficulty
        }
    }
}
