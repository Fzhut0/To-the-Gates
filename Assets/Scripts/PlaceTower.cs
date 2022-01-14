using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceTower : MonoBehaviour
{
    [SerializeField] GameObject towerPrefab;
    [SerializeField] GameObject placedPrefab;
    [SerializeField] Material originalMaterial;
    [SerializeField] Material overMaterial;
    [SerializeField] Material nodeMaterial;

    [SerializeField] int cost = 50;
    [SerializeField] int nodeSpawn = 75;

    MeshRenderer mRenderer;
    [SerializeField] bool isPlaceable = true;
    [SerializeField] bool isNode = false;


    private void Start()
    {
        mRenderer = GetComponent<MeshRenderer>();
        originalMaterial = mRenderer.material;
    }


    private void OnMouseDown()
    {
        PutTower();
        AwardNode();
    }

    void OnMouseOver()
    {
        ResourcesBank bank = FindObjectOfType<ResourcesBank>();
        MoraleBalance morale = FindObjectOfType<MoraleBalance>();
        if (isPlaceable == true && bank.CurrentBalance >= cost)
        {
            mRenderer.material = overMaterial;
        }
        if (isNode == true && morale.CurrentMorale >= nodeSpawn)
        {
            isPlaceable = false;
            mRenderer.material = nodeMaterial;
        }
    }

    private void OnMouseExit()
    {
        if (isPlaceable == true)
        {
            mRenderer.material = originalMaterial;
        }
        if (isNode == true)
        {
            mRenderer.material = originalMaterial;
        }
    }

    void PutTower()
    {
        ResourcesBank bank = FindObjectOfType<ResourcesBank>();
        if (isPlaceable == true && bank.CurrentBalance >= cost)
        {
            Instantiate(towerPrefab.gameObject, transform.position, Quaternion.identity);
            bank.Withdraw(cost);
            Instantiate(placedPrefab.gameObject, transform.position, Quaternion.identity);
        }
        isPlaceable = false;
    }

    void AwardNode()
    {
        MoraleBalance morale = FindObjectOfType<MoraleBalance>();
        ResourcesBank bank = FindObjectOfType<ResourcesBank>();

        if (isNode == true && morale.CurrentMorale >= nodeSpawn)
        {
            bank.Deposit(75);
        }
        isNode = false;
    }

}
