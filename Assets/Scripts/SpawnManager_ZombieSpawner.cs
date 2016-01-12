using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class SpawnManager_ZombieSpawner : NetworkBehaviour {

    [SerializeField]
    GameObject zombiePrefab;
    [SerializeField]
    GameObject zombieSpawn;
    private int counter;
    private int numberOfZombies = 50;

    public override void OnStartServer()
    {
        for(int i = 0; i < numberOfZombies; i++)
        {
            SpawnZombies();
        }
    }

    void SpawnZombies()
    {
        counter++;
        GameObject go = GameObject.Instantiate(zombiePrefab, zombieSpawn.transform.position, Quaternion.identity) as GameObject;
        go.GetComponent<Zombie_ID>().zombieID = "Zombie " + counter;
        NetworkServer.Spawn(go);
    }
}
