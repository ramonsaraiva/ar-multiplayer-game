using UnityEngine;
using System.Collections.Generic;

public class SpawnEventHandler : MonoBehaviour
{
    [SerializeField]
    private Camera mainCamera;

    [SerializeField]
    private Transform environment;

    [SerializeField]
    private Transform groundOffset;

    [SerializeField]
    private List<GameObject> spawns;

    private GameObject current;
    private int current_index;

    void Start()
    {
        current_index = 0;
        ChangeSpawn();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit[] hits;

            hits = Physics.RaycastAll(ray);

            foreach (var hit in hits)
            {
                Transform objectHit = hit.transform;
                if (objectHit.tag == "ChangeSpawn")
                {
                    ChangeSpawn();
                }

                if (objectHit.tag == "CreateSpawn")
                {
                    InstantiateSpawn();
                }
            }
        }
    }

    private void ChangeSpawn()
    {
        Destroy(current);
        GameObject spawn = spawns[current_index++ % spawns.Count];
        Vector3 spawnPosition = new Vector3(transform.position.x, transform.position.y + spawn.transform.localScale.y / 2 + 14f, transform.position.z);
        current = Instantiate(spawn, spawnPosition, transform.rotation) as GameObject;
        current.transform.parent = transform;
        DisablePrefabArenaBehaviours();
    }

    private void InstantiateSpawn()
    {
        Vector3 spawnPosition = new Vector3(current.transform.position.x, environment.position.y, current.transform.position.z);
        GameObject spawn = PhotonNetwork.Instantiate(spawns[(current_index - 1) % spawns.Count].name, spawnPosition, transform.rotation, 0) as GameObject;
    }

    private void DisablePrefabArenaBehaviours()
    {
        current.GetComponent<SpawnerBehaviour>().enabled = false;
    }
}
