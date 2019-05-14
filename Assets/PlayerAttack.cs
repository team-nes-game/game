using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other){
    	if(other.CompareTag("hitable")){
    		other.GetComponent<Hitable>().OnHit();
    	}
    }
}
