using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hitable : MonoBehaviour
{
	private Animator animator;

	void Start(){
		animator = GetComponent<Animator>();
	}

	public void OnHit(){
		animator.SetBool("Hit", true);
	}
}
