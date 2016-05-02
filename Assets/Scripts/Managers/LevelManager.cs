using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField]
    private GameObject playerPrefab;

    [SerializeField]
    private Transform arena;

    [SerializeField]
    private Transform playerStartPosition;

    private GameObject player;

    public void StartGame()
    {
        if (PhotonNetwork.isMasterClient)
        {
            player = PhotonNetwork.Instantiate("Player", playerStartPosition.position, Quaternion.identity, 0) as GameObject;
            GameObject[] spawners = GameObject.FindGameObjectsWithTag("Spawner");
            foreach (GameObject spawner in spawners)
            {
                if (spawner.transform.parent.tag == "Arena")
                    spawner.GetComponent<SpawnerBehaviour>().enabled = true;
            }
        }
    }

    public void EndGame()
    {
        if (PhotonNetwork.isMasterClient)
        {
            PhotonNetwork.DestroyAll();
            GameObject[] spawners = GameObject.FindGameObjectsWithTag("Spawner");
            foreach (GameObject spawner in spawners)
            {
                spawner.GetComponent<SpawnerBehaviour>().enabled = false;
            }
        }
    }
}
