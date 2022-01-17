using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyboxRotation : MonoBehaviour
{
    [SerializeField] float rotationSpeed = 1f;


    void Update()
    {
        RenderSettings.skybox.SetFloat("_Rotation", rotationSpeed * Time.time);
    }
}
