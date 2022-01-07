using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Enemy))]
public class EnemyMover1 : MonoBehaviour
{
    [SerializeField] List<PlaceTower> path = new List<PlaceTower>();
    [SerializeField] [Range(0f, 5f)] float speed = 1f;

    Enemy enemy;

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

        GameObject parent = GameObject.FindGameObjectWithTag("Path1");

        foreach (Transform child in parent.transform)
        {
            PlaceTower placetower = child.GetComponent<PlaceTower>();

            if (placetower != null)
            {
                path.Add(placetower);
            }
        }
    }

    public void ReturnToStart()
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
