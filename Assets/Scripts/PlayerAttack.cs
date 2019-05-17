using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
	public int knockback;
	public float kbTime;

    private void OnTriggerEnter2D(Collider2D other){
    	if(other.CompareTag("hitable")){
    		other.GetComponent<Hitable>().OnHit();
    	}
    	else if(other.CompareTag("enemy")){
    		//hit the enemy
    		other.GetComponent<Hitable>().OnHit();
    		//check if dead
    		EnemyParent cont = other.GetComponent<EnemyParent>();
    		if(cont.status != EnemyState.dead && cont.status != EnemyState.knocked){
	    		//apply knockback
	    		Rigidbody2D enemy = other.GetComponent<Rigidbody2D>();
	    		if(enemy != null){
	    			StartCoroutine(KnockRoutine(enemy));
	    		}
    		}
    	}
    }

    private IEnumerator KnockRoutine(Rigidbody2D enemy){
    	if(enemy != null){
            EnemyParent temp = enemy.GetComponent<EnemyParent>();
            temp.SetKnocked();
            enemy.isKinematic = false;
            Vector3 difference = enemy.transform.position - transform.position;
            difference = difference.normalized * knockback;
            enemy.AddForce(difference, ForceMode2D.Impulse);
            Debug.Log("Before 38");
    		yield return new WaitForSecondsRealtime(kbTime);
            Debug.Log("After 38");
            print("done with knockback");
    		enemy.velocity = Vector3.zero;
    		enemy.isKinematic = true;
    		temp.KnockedEnd();
    	}
    }
}
