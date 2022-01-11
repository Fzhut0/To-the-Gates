using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fence : MonoBehaviour
{

    [SerializeField] int maxHitPoints = 20;
    [SerializeField] public int currentHitPo = 20;
    [SerializeField] float range = 3f;
    [SerializeField] float healthTime = 2f;

    Enemy enemy;
    public string enemyTag = "Enemy";
    private void Awake()
    {
        maxHitPoints = currentHitPo;
    }

    private void Start()
    {
        enemy = GetComponent<Enemy>();
    }



    private void Update()
    {
        //     GameObject enemy = GameObject.FindGameObjectWithTag(enemyTag);
        //     if (enemy == null) { return; }
        ////    float enemyDistance = Vector3.Distance(transform.position, enemy.transform.position);

        //    if (enemyDistance <= range)
        //    {
        //        StartCoroutine(LosingHealth());
        //    }
        //     Invoke("Death", 2f);





        Invoke("Death", 1f);
    }


    private void OnTriggerEnter(Collider other)
    {
        StartCoroutine(LosingHealth());

    }



    IEnumerator LosingHealth()
    {

        while (true)
        {
            currentHitPo--;
            yield return new WaitForSeconds(healthTime);
        }

    }
    public void Death()
    {

        if (currentHitPo <= 0)
        {

            // gameObject.SetActive(false);
            Destroy(gameObject);
        }

    }

}
