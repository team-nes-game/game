using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour {
	// +-------------+
	// | Public      |
	// +-------------+
	public int MAX_HEALTH;
    public float MOVEMENT_SPEED;

    // +-----------+
    // | Private   |
    // +-----------+
    private bool ALIVE;
    private STATE STATUS;
    private int CUR_HEALTH;
    private Vector3 MOVEMENT;
    private Rigidbody2D SELF;
    private Animator ANIMATOR;
    private float LAST_X, LAST_Y;
    private enum STATE { idle, walk, start_attack, attacking, dead };

    // Start is called before the first frame update
    void Start() {
    	SELF       = GetComponent<Rigidbody2D>();
    	CUR_HEALTH = MAX_HEALTH;
    	STATUS     = STATE.idle;
    	MOVEMENT   = Vector3.zero;
    	ANIMATOR   = GetComponent<Animator>();
    }

	// Called every frame, keep it low on cost pls
    private void Update() {
    	if(STATUS == STATE.idle || STATUS == STATE.walk){
    		MoveCharacter();
    		Animate(MOVEMENT);
    	}
    	if(Input.GetAxisRaw("Attack") == 1 && STATUS != STATE.attacking){
    		STATUS = STATE.start_attack;
    	}
    }

    private void MoveCharacter() {
		// The movement vector being initialized
        MOVEMENT.x = Input.GetAxisRaw("Horizontal");
        MOVEMENT.y = Input.GetAxisRaw("Vertical");

        // Ensure that our player cannot move faster in
        // diagonal movement by clamping it, then speed
        // up our player by whatever factor is required
        MOVEMENT = Vector3.ClampMagnitude(MOVEMENT, 1);

    	SELF.MovePosition(transform.position + MOVEMENT * MOVEMENT_SPEED * Time.deltaTime);
    }

    private void Animate(Vector3 direction) {
    	// Idle animation
    	if (direction.x == 0f && direction.y == 0f) {
	    	ANIMATOR.SetFloat("lastX", LAST_X);
	    	ANIMATOR.SetFloat("lastY", LAST_Y);
	    	ANIMATOR.SetBool("Moving", false);
	    	STATUS = STATE.idle;
    	}
    	// Running animation where we set up which direction
    	// we were last facing in order to maintain consistent
    	// idle animations
    	else {
    		LAST_X = direction.x;
    		LAST_Y = direction.y;
    		ANIMATOR.SetBool("Moving", true);
    		STATUS = STATE.walk;
    	}

    	ANIMATOR.SetFloat("moveX", direction.x);
    	ANIMATOR.SetFloat("moveY", direction.y);
    }

    private void FixedUpdate() {
    	// Ded
    	if (CUR_HEALTH <= 0) {
    		print("Player killed");
    		STATUS = STATE.dead;
    	}
    	if(STATUS == STATE.start_attack){
    		StartCoroutine(AttackRoutine());
    	}
    }

    private IEnumerator AttackRoutine() {
    	STATUS = STATE.attacking;
    	ANIMATOR.SetFloat("lastX", LAST_X);
	    ANIMATOR.SetFloat("lastY", LAST_Y);
	    ANIMATOR.SetBool("Moving", false);
	    SELF.GetComponent<Rigidbody2D>().isKinematic = true;
    	ANIMATOR.SetBool("Attacking", true);
    	yield return null;   	
    	ANIMATOR.SetBool("Attacking", false);
    	yield return new WaitForSeconds(1f);
    	STATUS = STATE.idle;
    	SELF.GetComponent<Rigidbody2D>().isKinematic = false;
    }
}
//     public void TakeDmg(int dmg) {
//     	cur_health -= dmg;
//     }
// }
