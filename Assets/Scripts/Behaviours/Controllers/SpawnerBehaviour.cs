using UnityEngine;
using GameConstants;

public class SpawnerBehaviour : MonoBehaviour
{
    [SerializeField]
    private GameObject zomBearPrefab;
    [SerializeField]
    private GameObject zomBunnyPrefab;
    [SerializeField]
    private GameObject hellephantPrefab;

    [SerializeField]
    private Transform[] zomBunnySpawnLocations;
    [SerializeField]
    private Transform[] zomBearSpawnLocations;
    [SerializeField]
    private Transform[] hellephantSpawnLocations;

    private float nextZomBunnySpawn;
    private float nextZomBearSpawn;
    private float nextHellephantSpawn;

	private void Start()
    {
        nextZomBunnySpawn = Time.time + LevelConstants.ZomBunnySpawnRate;
        nextZomBearSpawn = Time.time + LevelConstants.ZomBearSpawnRate;
        nextHellephantSpawn = Time.time + LevelConstants.HellephantSpawnRate;
	}
	
	private void Update()
    {
        SpawnZomBunny();
        SpawnZomBear();
        SpawnHellephant();
	}

    private void SpawnZomBunny()
    {
        if (Time.time > nextZomBunnySpawn)
        {
            nextZomBunnySpawn = Time.time + LevelConstants.ZomBunnySpawnRate;
            GameObject zomBunny = PhotonNetwork.Instantiate("ZomBunny", zomBunnySpawnLocations[Random.Range(0, zomBunnySpawnLocations.Length)].position, Quaternion.identity, 0) as GameObject;
        }
    }

    private void SpawnZomBear()
    {
        if (Time.time > nextZomBearSpawn)
        {
            nextZomBearSpawn = Time.time + LevelConstants.ZomBearSpawnRate;
            GameObject zomBear = PhotonNetwork.Instantiate("ZomBear", zomBearSpawnLocations[Random.Range(0, zomBearSpawnLocations.Length)].position, Quaternion.identity, 0) as GameObject;
        }
    }

    private void SpawnHellephant()
    {
        if (Time.time > nextHellephantSpawn)
        {
            nextHellephantSpawn = Time.time + LevelConstants.HellephantSpawnRate;
            GameObject hellephant = PhotonNetwork.Instantiate("Hellephant", hellephantSpawnLocations[Random.Range(0, hellephantSpawnLocations.Length)].position, Quaternion.identity, 0) as GameObject;
        }
    }
}
