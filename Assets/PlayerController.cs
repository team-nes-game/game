using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public int MAX_HEALTH;
    private Rigidbody2D self;
    private int cur_health;
    private bool alive;
    private Animator animator;
    private Vector3 movement;

    // Start is called before the first frame update
    void Start()
    {
    	cur_health = MAX_HEALTH;
    	alive = true;
    	animator = GetComponent<Animator>();
    	self = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
    	if(cur_health <= 0){
    		print("Player killed");
    		alive = false;
    	}

        Vector2 pos = transform.position;

        movement = Vector3.zero;
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        if(movement != Vector3.zero){
        	self.MovePosition(transform.position + movement * speed * Time.deltaTime);
        	animator.SetFloat("MoveX", movement.x);
        	animator.SetFloat("MoveY", movement.y);
        	animator.SetBool("Walking", true);
        }
        else{
        	animator.SetBool("Walking", false);
        }
        /*
        if (Input.GetKey("w"))
        {
            pos.y += speed * Time.deltaTime;
            animator.SetFloat("MoveY", 1);
        }
        if (Input.GetKey("s"))
        {
            pos.y -= speed * Time.deltaTime;
            animator.SetFloat("MoveY", -1);
        }
        if (Input.GetKey("d"))
        {
            pos.x += speed * Time.deltaTime;
            animator.SetFloat("MoveX", 1);
        }
        if (Input.GetKey("a"))
        {
            pos.x -= speed * Time.deltaTime;
            animator.SetFloat("MoveX", -1);
        }


        transform.position = pos;
        */
    }
}
