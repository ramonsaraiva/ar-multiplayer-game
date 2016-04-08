using UnityEngine;

public class PlayerNetworkBehaviour : Photon.MonoBehaviour
{
    private Vector3 receivedPosition;
    private Quaternion receivedRotation;

    private Animator anim;

    private void Start()
    {
        receivedPosition = transform.position;
        receivedRotation = transform.rotation;
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if (photonView.isMine)
            return;

        bool isWalking = Vector3.Distance(receivedPosition, transform.position) > 0.05f;
        anim.SetBool("IsWalking", isWalking);

        transform.position = Vector3.Lerp(transform.position, receivedPosition, 5 * Time.deltaTime);
        transform.rotation = Quaternion.Lerp(transform.rotation, receivedRotation, 10 * Time.deltaTime);

        /*
        transform.position = receivedPosition;
        transform.rotation = receivedRotation;
        */
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
    public void Shoot()
    {
        PlayerShooting playerShooting = transform.GetComponentInChildren<PlayerShooting>();
        playerShooting.Shoot();
    }
}