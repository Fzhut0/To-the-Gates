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
    [SerializeField] public int nodeSpawn = 60;

    MeshRenderer mRenderer;
    [SerializeField] public bool isPlaceable = true;
    [SerializeField] bool isNode = false;


    private void Start()
    {
        mRenderer = GetComponent<MeshRenderer>();
        originalMaterial = mRenderer.material;
        GameObject nullTag = GameObject.FindGameObjectWithTag("PutNull");
        GameObject pauseTag = GameObject.FindGameObjectWithTag("Pause");
    }

    private void Update()
    {

    }

    private void OnMouseDown()
    {

        if (Time.timeScale == 1f)
        {
            PutTower();
        }
        AwardNode();
    }

    void OnMouseOver()
    {
        ResourcesBank bank = FindObjectOfType<ResourcesBank>();
        MoraleBalance morale = FindObjectOfType<MoraleBalance>();
        if (isPlaceable == true && bank.CurrentBalance >= cost && Time.timeScale == 1f)
        {
            mRenderer.material = overMaterial;
        }
        if (isNode == true && morale.CurrentMorale >= nodeSpawn && Time.timeScale == 1f)
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
        GameObject nullTag = GameObject.FindGameObjectWithTag("PutNull");
        GameObject pauseTag = GameObject.FindGameObjectWithTag("Pause");

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
