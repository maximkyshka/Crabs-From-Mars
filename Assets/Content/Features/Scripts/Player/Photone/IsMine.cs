using Photon.Pun;
using TMPro;
using UnityEngine;

public class IsMine : MonoBehaviour
{
    private PhotonView view;
    private MoveController moveController;
    private TMP_Text nickname;
    
    [SerializeField] private GameObject camera;
    
    private void Start()
    {
        view = GetComponent<PhotonView>();
        moveController = GetComponent<MoveController>();
        
        if (view.IsMine)
        {
            camera.SetActive(true);
            moveController.enabled = true;
        }
        else
        {
            camera.SetActive(false);
            moveController.enabled = false;
        }

        try
        {
            nickname.text = PhotonNetwork.NickName;
        }
        catch {}
    }
}