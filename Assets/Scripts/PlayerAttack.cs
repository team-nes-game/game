using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour {
    public int DAMAGE;
    public float FORCE;
    public float DURATION;

    private Rigidbody2D ENEMY;

    // void Start(){
    //     kb = new Knockback();
    // }

    private void OnTriggerEnter2D(Collider2D other){
    	if(other.CompareTag("hitable")){
    		other.GetComponent<Hitable>().OnHit();
    	}
    	else if(other.CompareTag("Enemy")){
    		//hit the enemy
    		//other.GetComponent<Hitable>().OnHit();
    		EnemyController cont = other.GetComponent<EnemyController>();
            cont.TakeDamage(DAMAGE);
            StartCoroutine(cont.Knockback(transform.position, FORCE, DURATION));
            // Rigidbody2D rb = GetComponentInParent<Rigidbody2D>();
            // Knockback.KB(other.GetComponent<Rigidbody2D>(), 
            //               rb,
            //               FORCE, DURATION);
    		// if(cont.status != EnemyState.dead && cont.status != EnemyState.knocked){
	    	// 	//apply knockback
	    	// 	Rigidbody2D enemy = other.GetComponent<Rigidbody2D>();
	    	// 	if(enemy != null){
	    	// 		StartCoroutine(KnockRoutine(enemy));
	    	// 	}
    		//}
    	}
    }
}
