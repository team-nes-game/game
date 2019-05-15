using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyParent : MonoBehaviour
{

	public int health;
	public int dmg;
	public float speed;
	public bool dead;
	public bool invuln;//whether or not the enemy can take damage

    // Start is called before the first frame update
    void Start()
    {
        dead = false;
        invuln = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetDead(){
    	dead = true;
    }
    public void SetInvuln(bool a){
    	invuln = a;
    }
}
