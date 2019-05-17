using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hitable : MonoBehaviour
{
	public Animator animator;

	public virtual void Start(){
		animator = GetComponent<Animator>();
	}

	public virtual void OnHit(){
		animator.SetBool("Hit", true);
	}
}
