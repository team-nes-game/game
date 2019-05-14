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
    private enum State {walk, attack_start, attacking, dead};
    private State status;

    // Start is called before the first frame update
    void Start()
    {
    	cur_health = MAX_HEALTH;
    	animator = GetComponent<Animator>();
    	self = GetComponent<Rigidbody2D>();
    	status = State.walk;
    }

    private void Update(){
    	//get input here
    	movement = Vector3.zero;
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        if(Input.GetButtonDown("Attack")){
        	status = State.attack_start;
        }
    }

    private void FixedUpdate()
    {
    	if(cur_health <= 0){
    		print("Player killed");
    		status = State.dead;
    	}
    	//deal with input here
    	//can probably be a switch
        if(status == State.attack_start){
        	StartCoroutine(AttackRoutine());
        }
        else if(status == State.walk){
        	if(movement != Vector3.zero){
        		Vector2 pos = transform.position;
	        	self.MovePosition(transform.position + movement * speed * Time.deltaTime);
	        	animator.SetFloat("MoveX", movement.x);
	        	animator.SetFloat("MoveY", movement.y);
	        	animator.SetBool("Walking", true);
        	}
	        else{
	        	animator.SetBool("Walking", false);
	        }
	    }
    }

    private IEnumerator AttackRoutine(){
    	animator.SetBool("Attacking", true);
    	status = State.attacking;
    	yield return null;   	
    	animator.SetBool("Attacking", false);
    	yield return new WaitForSeconds(.3f);
    	status = State.walk;
    }

    public void TakeDmg(int dmg){
    	cur_health -= dmg;
    }
}
