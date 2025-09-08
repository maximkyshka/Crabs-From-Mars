using UnityEngine;
using Photon.Pun;

public class HudController : MonoBehaviourPunCallbacks
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip clip;
    public void LeaveGame()
    {
        Application.Quit();
    }
    public void ClickSound()
    {
        audioSource.PlayOneShot(clip);
    }
    public void JoinRandomRoom()
    {
        PhotonNetwork.JoinRandomRoom();
    }
}
