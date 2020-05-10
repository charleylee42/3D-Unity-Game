using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlidingDoorManager : MonoBehaviour {
	public GameObject door;
	bool open;
	bool opened;
	int countBeforeClosing;

	// Use this for initialization
	void Start () {
		open = false;
		opened = false;
	}

	// Update is called once per frame
	void Update () {
		if (open) {
			if (door.transform.position.z > -12) {
				door.transform.Translate (Time.deltaTime, 0, 0, door.transform);
			} 
			else {
				open = false;
				opened = true;
			}
		}

		else if (opened) {
			StartCoroutine (DoSomething ());
		}

		else {
			if (door.transform.position.z < -9.444) {
				door.transform.Translate (-Time.deltaTime, 0, 0, door.transform);
			}
		}
	}

	void OnTriggerEnter(Collider other) {
		Debug.Log ("DoorManager::OnTriggerEnter");
		HeroManager heroManager = (HeroManager)other.gameObject.GetComponent (typeof(HeroManager));
		if (heroManager != null && heroManager.blueKey) {
			open = true;
		}
	}

	IEnumerator DoSomething() {
		yield return new WaitForSeconds (3);
		opened = false;
	}

}
