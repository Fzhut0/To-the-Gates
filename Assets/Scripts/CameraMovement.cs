using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed = 10f;
    [SerializeField] Vector2 panLimit;
    [SerializeField] GameObject scoreBoard;




    private void Start()
    {
        Time.timeScale = 1f;


    }


    void Update()
    {
        MoveCamera();
        QuitApp();
        StatBoard();
    }



    void MoveCamera()
    {
        Vector3 pos = transform.position;

        pos.x = Mathf.Clamp(pos.x, -panLimit.x, panLimit.x);
        pos.z = Mathf.Clamp(pos.z, -panLimit.y, panLimit.y);

        if (Input.GetKey(KeyCode.A))
        {
            pos.z -= moveSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D))
        {
            pos.z += moveSpeed * Time.deltaTime;
        }


        if (Input.GetKey(KeyCode.W))
        {
            pos.x -= moveSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.S))
        {
            pos.x += moveSpeed * Time.deltaTime;

        }
        transform.position = pos;
    }

    public void QuitApp()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    void StatBoard()
    {
        if (Input.GetKey(KeyCode.Tab))
        {
            scoreBoard.SetActive(true);
        }
        else
        {
            scoreBoard.SetActive(false);
        }
    }

    public void QuitAppBtn()
    {
        Application.Quit();
    }
}
