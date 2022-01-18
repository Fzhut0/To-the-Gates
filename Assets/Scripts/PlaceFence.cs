using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceFence : MonoBehaviour
{

    [SerializeField] GameObject fencePrefab;
    [SerializeField] int cost = 50;

    [SerializeField] bool fencePlaceableLeft = true;
    [SerializeField] bool fencePlaceableFw = true;




    private void OnMouseDown()
    {
        if (Time.timeScale == 1f)
        {
            PutFence();
        }
    }

    void PutFence()
    {
        ResourcesBank bank = FindObjectOfType<ResourcesBank>();
        if (fencePlaceableLeft == true && bank.CurrentBalance >= cost)
        {
            Instantiate(fencePrefab.gameObject, transform.position, Quaternion.LookRotation(Vector3.back));
            bank.Withdraw(cost);
        }
        fencePlaceableLeft = false;

        if (fencePlaceableFw == true && bank.CurrentBalance >= cost)
        {
            Instantiate(fencePrefab.gameObject, transform.position, Quaternion.LookRotation(Vector3.right));
            bank.Withdraw(cost);
        }
        fencePlaceableFw = false;
    }
}

