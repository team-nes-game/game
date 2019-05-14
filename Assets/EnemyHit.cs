using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHit : Hitable
{
	public EnemyParent controller;

	public override void Start(){
		base.Start();
		controller = this.gameObject.GetComponent<EnemyParent>();
	}

    public override void OnHit(){
    	//needs animations for this to work
    	//base.OnHit();
    	controller.health -= 1;
    	if(controller.health <= 0){
    		controller.SetDead();
    		animator.SetBool("IsDead", true);
    	}
    }
}
