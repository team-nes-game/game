using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public int MAX_HEALTH;
    public GameObject self;
    private int cur_health;
    private bool alive;

    // Start is called before the first frame update
    void Start()
    {
    	cur_health = MAX_HEALTH;
    	alive = true;
    }

    private void FixedUpdate()
    {
    	if(cur_health <= 0){
    		print("Player killed");
    		alive = false;
    	}

        Vector2 pos = transform.position;

        if (Input.GetKey("w"))
        {
            pos.y += speed * Time.deltaTime;
        }
        if (Input.GetKey("s"))
        {
            pos.y -= speed * Time.deltaTime;
        }
        if (Input.GetKey("d"))
        {
            pos.x += speed * Time.deltaTime;
        }
        if (Input.GetKey("a"))
        {
            pos.x -= speed * Time.deltaTime;
        }


        transform.position = pos;
    }
}
