using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalDoorManager : MonoBehaviour {

	Animator animator;
	AudioSource audioSource;

	bool opening;
	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator>();
		audioSource = GetComponent<AudioSource>();
		opening = false;
		animator.SetBool ("opening", opening);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnMouseDown()
	{
		Debug.Log ("NormalDoorManager::OnMouseDown()");
		opening = !opening;
		animator.SetBool("opening", opening);
		GetComponent<AudioSource>().Play();
	}
}
