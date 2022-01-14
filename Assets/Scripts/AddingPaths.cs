using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddingPaths : MonoBehaviour
{

    [SerializeField] GameObject path1;
    [SerializeField] GameObject path2;


    void Start()
    {
        Instantiate(path1);
        Instantiate(path2);

    }

}




