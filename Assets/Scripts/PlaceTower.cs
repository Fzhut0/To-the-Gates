using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceTower : MonoBehaviour
{
    [SerializeField] GameObject towerPrefab;
    [SerializeField] GameObject placedPrefab;
    [SerializeField] Material originalMaterial;
    [SerializeField] Material overMaterial;

    [SerializeField] int cost = 50;

    MeshRenderer mRenderer;
    [SerializeField] bool isPlaceable = true;


    private void Start()
    {
        mRenderer = GetComponent<MeshRenderer>();
        originalMaterial = mRenderer.material;
    }

    private void OnMouseDown()
    {
        PutTower();
    }

    void OnMouseOver()
    {
        mRenderer.material = overMaterial;
    }

    private void OnMouseExit()
    {
        mRenderer.material = originalMaterial;
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

}
