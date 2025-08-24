using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class PlayerSpavn : MonoBehaviourPunCallbacks
{
    [SerializeField] private GameObject _player;

    [SerializeField] private float _randomSpavnOfset;

    void Start()
    {
        Vector3 RandomSpavnOfset = new Vector3(
                Random.Range(-_randomSpavnOfset, _randomSpavnOfset), 
                0, 
                Random.Range(-_randomSpavnOfset, _randomSpavnOfset)
                );

        GameObject t =  PhotonNetwork.Instantiate(_player.name, transform.position + RandomSpavnOfset, Quaternion.identity);
        t.name = PhotonNetwork.NickName;
    }

    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        Debug.LogFormat("Player {0} left room", otherPlayer.NickName);
    }
    
    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        Debug.LogFormat("Player {0} entered room", newPlayer.NickName);
    }
    
    public override void OnJoinedRoom()
    {
        string name = PhotonNetwork.LocalPlayer.NickName;
        
        Debug.LogFormat("Player {0} properties updated", name);
        
        Vector3 RandomSpavnOfset = new Vector3(
            Random.Range(-_randomSpavnOfset, _randomSpavnOfset), 
            0, 
            Random.Range(-_randomSpavnOfset, _randomSpavnOfset)
        );
        
        GameObject t = PhotonNetwork.Instantiate(_player.name, transform.position + RandomSpavnOfset, Quaternion.identity);
        
        t.name = name;
    }
}
