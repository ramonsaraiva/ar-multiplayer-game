using UnityEngine;
using GameConstants;

public class SpawnerBehaviour : MonoBehaviour
{
    [SerializeField]
    private GameObject prefab;
    [SerializeField]
    private string name;
    [SerializeField]
    private float rate;

    private float nextSpawn;

	private void Start()
    {
        nextSpawn = Time.time + rate;
	}
	
	private void Update()
    {
        Spawn();
	}

    private void Spawn()
    {
        print("spawning");
        if (Time.time > nextSpawn)
        {
            nextSpawn = Time.time + rate;
            GameObject enemy = PhotonNetwork.Instantiate(name, transform.position, Quaternion.identity, 0) as GameObject;
        }
    }
}
