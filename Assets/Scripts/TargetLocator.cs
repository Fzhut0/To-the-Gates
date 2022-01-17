using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetLocator : MonoBehaviour
{
    [SerializeField] Transform weapon;
    [SerializeField] public float range = 25f;
    [SerializeField] float enemyHeight = 10f;


    [SerializeField] ParticleSystem particleShoot;

    Enemy targetEnemy;

    Transform target;




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


            weapon.LookAt(new Vector3(target.transform.position.x, enemyHeight, target.transform.position.z));
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


        if (morale >= 35)
        {
            range = 30f;
        }
        if (morale >= 100)
        {
            range = 32f;
        }
        if (morale >= 200)
        {
            range = 35f;
        }


        /*  switch (morale)
          {
              case 50:
                  range = 30f;
                  break;
              case 60:
                  range = 32f;
                  break;
              case 250:
                  range = 35f;
                  break;
          }
        */
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
