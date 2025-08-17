using UnityEngine;
using Photon.Pun;

public class PlayerSpavn : MonoBehaviour
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
        
        PhotonNetwork.Instantiate(_player.name, transform.position + RandomSpavnOfset, Quaternion.identity);
    }
}
