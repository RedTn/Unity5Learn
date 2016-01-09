using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class MasterScript : NetworkBehaviour {

	// Use this for initialization
	void Start () {
        //Cursor.visible = false;
        //Cursor.lockState = CursorLockMode.Locked;
        //Cursor.lockState = CursorLockMode.None;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey("escape"))
            Application.Quit();
    }
}
