using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Knockback
{
    // public static void KB(Rigidbody2D attacker, Rigidbody2D attackee, 
    // 	           float kb, float kbtime){
    // 	StartCoroutine(KnockRoutine(attacker, attackee, kb, kbtime));
    // }

    public static IEnumerator KB(Rigidbody2D attacker, Rigidbody2D attackee, 
    	           float kb, float kbtime){
    	if(attackee != null){
            EnemyController temp = attackee.GetComponent<EnemyController>();
            temp.SetKnocked();
            attackee.isKinematic = false;
            Vector3 difference = attackee.transform.position - attacker.transform.position;
            difference = difference.normalized * kb;
            attackee.AddForce(difference, ForceMode2D.Impulse);
    		yield return new WaitForSecondsRealtime(kbtime);
    		attackee.velocity = Vector3.zero;
    		attackee.isKinematic = true;
    		temp.KnockedEnd();
    	}
    }
}
