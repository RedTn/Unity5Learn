using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class GameManager_ZombieSpawner : NetworkBehaviour {

    [SerializeField]
    GameObject zombiePrefab;
    [SerializeField]
    GameObject zombieSpawn;
    private int counter;
    private int numberOfZombies = 10;

    public override void OnStartServer()
    {
        for(int i = 0; i < numberOfZombies; i++)
        {
            SpawnZombies();
        }
    }

    void SpawnZombies()
    {
        //counter

        GameObject go = GameObject.Instantiate(zombiePrefab, zombieSpawn.transform.position, Quaternion.identity) as GameObject;
        NetworkServer.Spawn(go);
    }

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
