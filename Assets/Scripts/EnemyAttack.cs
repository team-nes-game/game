using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public int DAMAGE;
    public float FORCE;
    public float DURATION;

    private void OnTriggerEnter2D(Collider2D other){
    	if(other.CompareTag("Player")){
    		PlayerController cont = other.GetComponent<PlayerController>();
    		cont.TakeDmg(DAMAGE, FORCE, DURATION, transform.position);
    	} 
    }
}
