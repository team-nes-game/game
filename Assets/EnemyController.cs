using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : EnemyParent
{
    public GameObject player;
    public float backSpeed;
    public float maxDist; //starts chasing
    public float minDist; //attacks at
    public Transform initial_pos; //where it started

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(status != EnemyState.dead && status != EnemyState.knocked){
            float distance = Vector3.Distance(player.transform.position, transform.position);

            if (distance < maxDist && distance > minDist)
            {
                transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
            }
            else if(distance == minDist)
            {
                // do nothing
            }
            /*
            else if(distance < minDist)
            {
                transform.position -= (player.transform.position - transform.position) * (1 / backSpeed) * Time.deltaTime;
            }*/
        }
    }
}
