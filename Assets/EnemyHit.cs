using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHit : Hitable
{
	public int health;

    public override void OnHit(){
    	//needs animations for this to work
    	//base.OnHit();

    	health -= 1;
    	if(health <= 0){
    		this.gameObject.GetComponent<EnemyController>().SetDead();
    		animator.SetBool("IsDead", true);
    	}
    }
}
