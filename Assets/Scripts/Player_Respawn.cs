using UnityEngine;
using System.Collections;
using UnityEngine.Networking;
using UnityEngine.UI;

public class Player_Respawn : NetworkBehaviour {

    private Player_Health healthScript;
    private Image crossHairImage;
    private GameObject respawnButton;
    public Transform myTransform;

    public override void PreStartClient()
    {
        healthScript = GetComponent<Player_Health>();
        healthScript.EventRespawn += EnablePlayer;
    }


    public override void OnStartLocalPlayer()
    {
        crossHairImage = GameObject.Find("Crosshair Image").GetComponent<Image>();
        SetRespawnButton();
    }

    // Use this for initialization
    void Start () {
        
        
	}

    void SetRespawnButton ()
    {
        if(isLocalPlayer)
        {
            respawnButton = GameObject.Find("GameManager").GetComponent<GameManager_References>().respawnButton;
            respawnButton.GetComponent<Button>().onClick.AddListener(CommenceRespawn);
            respawnButton.SetActive(false);
        }
    }

    public override void OnNetworkDestroy()
    {
        healthScript.EventRespawn -= EnablePlayer;
    }

    void EnablePlayer()
    {
        GetComponent<CharacterController>().enabled = true;
        GetComponent<Player_Shoot>().enabled = true;
        GetComponent<BoxCollider>().enabled = true;
        //GetComponent<Transform>().transform = GameObject.FindGameObjectWithTag("Respawn").transform;

        Renderer[] renderers = GetComponentsInChildren<Renderer>();
        foreach (Renderer ren in renderers)
        {
            ren.enabled = true;
        }

        if (isLocalPlayer)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>().enabled = true;
            crossHairImage.enabled = true;
            respawnButton.SetActive(false);
            myTransform.position = new Vector3(200f, 1f, 200f);
        }
    }

    void CommenceRespawn()
    {
        CmdRespawnOnServer();
    }

    [Command]
    void CmdRespawnOnServer()
    {
        healthScript.ResetHealth();
    }
}
