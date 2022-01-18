using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Enemy))]
public class EnemyMover2 : MonoBehaviour
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
        StartCoroutine(FollowPath());
    }

    private void Start()
    {

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

        GameObject parent = GameObject.FindGameObjectWithTag("Path4");

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





    IEnumerator FollowPath()
    {
        foreach (PlaceTower placetower in path)
        {
            Vector3 startPosition = transform.position;
            Vector3 endPosition = placetower.transform.position;
            float travelPercent = 0f;

            transform.LookAt(endPosition);

            GameObject fence = GameObject.FindGameObjectWithTag(fenceTag);

            if (fence != null && Vector3.Distance(transform.position, fence.transform.position) < range)
            {
                GetComponent<Animator>().SetBool("Attack", true);
                gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
                GetComponent<Animator>().SetBool("RUN", false);
            }



            while (GetComponent<Animator>().GetBool("Attack"))
            {
                if (fence != null && Vector3.Distance(transform.position, fence.transform.position) > range || fence == null)
                {
                    GetComponent<Animator>().SetBool("Attack", false);
                    gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
                    GetComponent<Animator>().SetBool("RUN", true);
                }
                yield return new WaitForEndOfFrame();
            }





            while (travelPercent < 1f)
            {
                travelPercent += Time.deltaTime * speed;
                transform.position = Vector3.Lerp(startPosition, endPosition, travelPercent);
                GetComponent<Animator>().SetBool("Attack", false);
                GetComponent<Animator>().SetBool("RUN", true);
                yield return new WaitForEndOfFrame();
            }


        }
        FinishPath();
    }
}
