using UnityEngine;
using System.Collections.Generic;

public class ObstacleEventHandler : MonoBehaviour
{
    [SerializeField]
    private Camera mainCamera;

    [SerializeField]
    private Transform environment;

    [SerializeField]
    private List<GameObject> obstacles;

    private GameObject current;
    private int current_index;

    void Start()
    {
        current_index = 0;
        ChangeObstacle();
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
                if (objectHit.tag == "ChangeObstacle")
                {
                    ChangeObstacle();
                }

                if (objectHit.tag == "CreateObstacle")
                {
                    InstantiateObstacle();
                }
            }
        }
    }

    private void ChangeObstacle()
    {
        Destroy(current);
        GameObject obstacle = obstacles[current_index++ % obstacles.Count];
        Vector3 obstaclePosition = new Vector3(transform.position.x, transform.position.y + obstacle.transform.localScale.y / 2 + 10f, transform.position.z);
        current = Instantiate(obstacle, obstaclePosition, transform.rotation) as GameObject;
        current.transform.parent = transform;
        DisablePrefabArenaBehaviours();
    }

    private void InstantiateObstacle()
    {
        Vector3 obstaclePosition = new Vector3(current.transform.position.x, environment.position.y, current.transform.position.z);
        GameObject obstacle = PhotonNetwork.Instantiate(obstacles[(current_index - 1) % obstacles.Count].name, obstaclePosition, transform.rotation, 0) as GameObject;
    }

    private void DisablePrefabArenaBehaviours()
    {
        current.GetComponent<NavMeshObstacle>().enabled = false;
        current.GetComponent<BelongsToArenaBehaviour>().enabled = false;
        current.GetComponent<PhotonView>().enabled = false;
    }
}
