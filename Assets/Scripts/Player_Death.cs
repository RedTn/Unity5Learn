﻿using UnityEngine;
using System.Collections;
using UnityEngine.Networking;
using UnityEngine.UI;

public class Player_Death : NetworkBehaviour {

    private Player_Health healthScript;
    private Image crossHairImage;

    public override void PreStartClient()
    {
        healthScript = GetComponent<Player_Health>();
        healthScript.EventDie += DisablePlayer;
    }

    // Use this for initialization
    void Start () {
        
        
	}

    public override void OnStartLocalPlayer()
    {
        crossHairImage = GameObject.Find("Crosshair Image").GetComponent<Image>();
    }

    public override void OnNetworkDestroy()
    {
        healthScript.EventDie -= DisablePlayer;
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    void DisablePlayer()
    {
        GetComponent<CharacterController>().enabled = false;
        GetComponent<Player_Shoot>().enabled = false;
        GetComponent<BoxCollider>().enabled = false;

        Renderer[] renderers = GetComponentsInChildren<Renderer>();
        foreach(Renderer ren in renderers)
        {
            ren.enabled = false;
        }

        healthScript.isDead = true;

        if(isLocalPlayer)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>().enabled = false;
            crossHairImage.enabled = false;
            GameObject.Find("GameManager").GetComponent<GameManager_References>().respawnButton.SetActive(true);
            //Respawn button
        }
    }
}
