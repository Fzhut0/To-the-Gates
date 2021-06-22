using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceTower : MonoBehaviour
{
    [SerializeField] GameObject towerPrefab;



    private void OnMouseDown()
    {

        Instantiate(towerPrefab.gameObject, transform.position, Quaternion.identity);
    }



}
