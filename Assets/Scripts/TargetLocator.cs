using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetLocator : MonoBehaviour
{
    [SerializeField] Transform weapon;
    [SerializeField] float range = 15f;

    [SerializeField] ParticleSystem particleShoot;

    Enemy targetEnemy;

    Transform target;
    GameObject mene;



    public string enemyTag = "Enemy";



    private void Start()
    {

        var particleEmission = particleShoot.emission;
        particleShoot.Play();
        particleEmission.enabled = false;


        InvokeRepeating("FindClosestTarget", 0f, 0.5f);

    }

    void Update()
    {

        AimWeapon();

        IncreaseRange();

    }

    private void AimWeapon()
    {
        if (target != null)
        {
            float targetDistance = Vector3.Distance(transform.position, target.position);

            weapon.LookAt(target);
            if (targetDistance < range && targetEnemy.enabled)
            {
                Attack(true);
            }
            else
            {

                Attack(false);
            }
        }
    }

    private void Attack(bool isActive)
    {
        var particleEmission = particleShoot.emission;
        particleEmission.enabled = isActive;
    }


    void FindClosestTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        Transform closestTarget = null;
        float maxDistance = Mathf.Infinity;

        foreach (GameObject enemy in enemies)
        {
            float targetDistance = Vector3.Distance(transform.position, enemy.transform.position);

            if (targetDistance < maxDistance)
            {
                maxDistance = targetDistance;
                closestTarget = enemy.transform;

            }
        }

        if (closestTarget != null && maxDistance <= range)
        {
            target = closestTarget.transform;
            targetEnemy = closestTarget.GetComponent<Enemy>();
        }
        else
        {
            target = null;
        }


    }

    void IncreaseRange()
    {
        int morale = FindObjectOfType<MoraleBalance>().CurrentMorale;

        switch (morale)
        {
            case 55:
                range = 30f;
                break;
            case 60:
                range = 35f;
                break;
            default:
                break;
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
