using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelayTrigger : MonoBehaviour {

	public static float delaySecond = 5.0f;

	private WaitForSeconds delayDuration = new WaitForSeconds(delaySecond);
	private iTweenManager iTweenManagerObj;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}

	// when isTriiger of the collider is off
	//	void OnCollisionEnter(Collision coll)
	//	{
	//		Debug.Log ("FadeOutTrigger::OnCollisionEnter(): hello1");
	//		if (coll.collider.tag == "CUT_SCENE_CAMERA") {
	//			//coll.collider.gameObject.SetActive (false);
	//			iTweenManager iTweenManagerObj = (iTweenManager)coll.collider.gameObject.GetComponent (typeof(iTweenManager));
	//			iTweenManagerObj.fadeOutIn ();
	//		}
	//	}

	// when isTriiger of the collider is on
	void OnTriggerEnter(Collider other)
	{
		Debug.Log ("DelayTrigger::OnTriggerEnter()");

		if (other.tag == "CUT_SCENE_CAMERA") {
			Debug.Log ("DelayTrigger::OnCollisionEnter(): delaySecond = " + delaySecond);
			//coll.collider.gameObject.SetActive (false);
			iTweenManagerObj = (iTweenManager)other.gameObject.GetComponent (typeof(iTweenManager));
			iTweenManagerObj.togglePause ();
			StartCoroutine (ShotEffect ());

		}
	}

	private IEnumerator ShotEffect()
	{
		//Wait for .07 seconds
		//same as sleep
		yield return delayDuration;

		iTweenManagerObj.togglePause ();
		gameObject.SetActive (false);
	} 
}

