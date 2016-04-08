using UnityEngine;
using CompleteProject;


public class EnemyNetworkBehaviour : Photon.MonoBehaviour
{
    private Vector3 receivedPosition;
    private Quaternion receivedRotation;

    private void Start()
    {
        receivedPosition = transform.position;
        receivedRotation = transform.rotation;
    }

    private void Update()
    {
        if (photonView.isMine)
            return;

        transform.position = Vector3.Lerp(transform.position, receivedPosition, 5 * Time.deltaTime);
        transform.rotation = Quaternion.Lerp(transform.rotation, receivedRotation, 10 * Time.deltaTime);
    }

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.isWriting)
        {
            stream.SendNext(transform.position);
            stream.SendNext(transform.rotation);

            return;
        }

        receivedPosition = (Vector3) stream.ReceiveNext();
        receivedRotation = (Quaternion) stream.ReceiveNext();
    }

    [PunRPC]
    public void Attack()
    {
        EnemyAttack enemyAttack = GetComponent<EnemyAttack>();
        enemyAttack.Attack();
    }

    [PunRPC]
    public void TakeDamage(int damagePerShot, Vector3 point)
    {
        EnemyHealth enemyHealth = GetComponent<EnemyHealth>();
        enemyHealth.TakeDamage(damagePerShot, point);
    }
}
