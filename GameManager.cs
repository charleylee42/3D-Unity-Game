using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

    public Light fireLight;
    public GameObject fireObject;
    public GameObject guardObject;
    public GameObject escaper2Object;
    public GameObject escaper3Object;
    public Camera cam1;
    public Camera cam2;
    public Camera cam3;
    public float DelaySecondsForFire = 3.0F;
    public bool fireAppeared = false;
    private bool fireShow;
    private bool guardShow;
    private bool escaper2Show;
    private bool escaper3Show;

    // Use this for initialization
    void Start () {
        //  audio.Play();
        //}
        fireShow = true;
        guardShow = true;

        cam1.enabled = true;
        cam2.enabled = false;
        cam3.enabled = false;
    }
    
    // Update is called once per frame
    void Update () {
        if (Input.GetKeyUp (KeyCode.F)) {
            toggleFireLight ();
        }

        if (!fireAppeared) {
            DelaySecondsForFire -= Time.deltaTime;
            if (DelaySecondsForFire < 0) {
                toggleFireLight();
                fireAppeared = true;
            }
        }
    }

    void toggleAudio() {
        if (audio.isPlaying) {
                audio.Pause ();
        } else {
            audio.Play();
        }
    }

    void toggleFireLight() {
        fireLight.enabled = !fireLight.enabled;
        fireShow = !fireShow;
        fireObject.SetActive(fireShow);
    }

    void toggleGuard() {
        guardShow = !guardShow;
        guardObject.SetActive(guardShow);
    }

    void toggleEscaper2() {
        escaper2Show = !escaper2Show;
        escaper2Object.SetActive(escaper2Show);   
    }

    void toggleEscaper3() {
        escaper3Show = !escaper3Show;
        escaper3Object.SetActive(escaper3Show);
    }

    void HideAllCams () { 
        cam1.enabled = false;
        cam2.enabled = false;
        cam3.enabled = false;
    }

    void ShowCam1 () {
        HideAllCams ();
        cam1.enabled = true;
    } 
    
    void ShowCam2 () {
        HideAllCams ();
        cam2.enabled = true;
    } 
    
    void ShowCam3 () {
        HideAllCams ();
        cam3.enabled = true;
    }    
}
