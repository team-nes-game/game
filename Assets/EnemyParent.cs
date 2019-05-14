using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyParent : MonoBehaviour
{

	public int health;
	public int dmg;
	public float speed;
	public bool dead;

    // Start is called before the first frame update
    void Start()
    {
        dead = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetDead(){
    	dead = true;
    }
}
