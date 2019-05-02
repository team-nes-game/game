using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public GameObject player;
    public float speed;
    public float backSpeed;
    public float maxDist;
    public float minDist;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(player.transform.position, transform.position);

        if (distance < maxDist && distance > minDist)
        {
            transform.position += (player.transform.position - transform.position) * (1 / speed) * Time.deltaTime;
        }
        else if(distance == minDist)
        {
            // do nothing
        }
        else if(distance < minDist)
        {
            transform.position -= (player.transform.position - transform.position) * (1 / backSpeed) * Time.deltaTime;
        }

    }
}
