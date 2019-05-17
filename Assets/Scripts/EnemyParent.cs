using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyState {idle, moving, knocked, attacking, dead};

public class EnemyParent : MonoBehaviour
{

	public int health;
	public int dmg;
	public float speed;
	public EnemyState status;

    // Start is called before the first frame update
    void Start()
    {
        status = EnemyState.idle;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetDead(){
    	status = EnemyState.dead;
    }
    public void SetKnocked(){
    	if(status != EnemyState.dead){
    		status = EnemyState.knocked;
    	}
    }
    public void KnockedEnd(){
    	if(status != EnemyState.dead){
    		status = EnemyState.idle;
    	}
    }
}
