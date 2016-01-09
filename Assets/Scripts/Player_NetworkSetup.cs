using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class Player_NetworkSetup : NetworkBehaviour {

    [SerializeField]
    Camera FPSChacracterCam;
    [SerializeField]
    AudioListener audioListener;

	// Use this for initialization
	void Start () {
	    if(isLocalPlayer)
        {
            GameObject.Find("Scene Camera").SetActive(false);
            //GetComponent<CharacterController>().enabled = true;
            GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>().enabled = true;
            FPSChacracterCam.enabled = true;
            audioListener.enabled = true;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
	}
	
}
