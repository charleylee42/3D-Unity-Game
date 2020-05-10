using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DoorButtonManager : MonoBehaviour
{
	public GameObject door;
	bool open;
	bool opened;
	int countBeforeClosing;

	// Use this for initialization
	void Start () {
		open = false;
		opened = false;
		countBeforeClosing = 3;
	}

	// Update is called once per frame
	void Update () {
		if (open) {
			if (door.transform.position.x < -3.5) {
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
			if (door.transform.position.x > -6.0) {
				door.transform.Translate (-Time.deltaTime, 0, 0, door.transform);
			}
		}
	}

	void OnMouseUp()
	{
		Debug.Log ("DoorButtonManager::OnMouseUp()");
	}

	void OnMouseDown()
	{
		Debug.Log ("DoorButtonManager::OnMouseDown()");
		open = true;
	}

	IEnumerator DoSomething() {
		yield return new WaitForSeconds (3);
		opened = false;
	}
}
