using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
[RequireComponent(typeof(Enemy))]
public class EnemyMover : MonoBehaviour
{
    [SerializeField] List<PlaceTower> path = new List<PlaceTower>();
    [SerializeField] [Range(0f, 5f)] float speed = 1f;
    [SerializeField] float range = 3f;

    EnemyHealth health;
    Enemy enemy;
    Fence fence;
    Animator attack;


    public string fenceTag = "Fence";

    private void OnEnable()
    {

        FindPath();
        ReturnToStart();
        GetComponent<Animator>().SetBool("RUN", true);
        StartCoroutine(FollowPath());
    }

    private void Start()
    {
        health = GetComponent<EnemyHealth>();
        enemy = GetComponent<Enemy>();

    }

    private void Update()
    {
        if (enemy.enabled == false)
        {
            enemy.enabled = true;
        }
    }



    void FindPath()
    {
        path.Clear();

        GameObject parent = GameObject.FindGameObjectWithTag("Path");

        foreach (Transform child in parent.transform)
        {
            PlaceTower placetower = child.GetComponent<PlaceTower>();

            if (placetower != null)
            {
                path.Add(placetower);
            }
        }
    }

    private void ReturnToStart()
    {

        transform.position = path[0].transform.position;

    }

    void FinishPath()
    {
        enemy.WithdrawResources();
        gameObject.SetActive(false);

    }

    private void OnTriggerEnter(Collider other)
    {
        GetComponent<Animator>().SetBool("RUN", false);
        GetComponent<Animator>().SetBool("Attack", true);
    }



    IEnumerator FollowPath()
    {
        foreach (PlaceTower placetower in path)
        {
            Vector3 startPosition = transform.position;
            Vector3 endPosition = placetower.transform.position;
            float travelPercent = 0f;


            transform.LookAt(endPosition);





            while (GetComponent<Animator>().GetBool("Attack"))
            {
                GameObject fence = GameObject.FindGameObjectWithTag(fenceTag);
                // float fenceDistance = Vector3.Distance(transform.position, fence.transform.position);

                if (fence == null)
                {
                    GetComponent<Animator>().SetBool("Attack", false);
                    GetComponent<Animator>().SetBool("RUN", true);

                }
                yield return null;
            }


            while (travelPercent < 1f)
            {
                travelPercent += Time.deltaTime * speed;
                transform.position = Vector3.Lerp(startPosition, endPosition, travelPercent);
                yield return new WaitForEndOfFrame();
            }


        }
        FinishPath();
    }
}
