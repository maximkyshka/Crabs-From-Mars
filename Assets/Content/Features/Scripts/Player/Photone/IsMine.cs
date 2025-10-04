using Photon.Pun;
using TMPro;
using UnityEngine;

public class IsMine : MonoBehaviour
{
    private PhotonView view;
    //private //PlayerMovment playerMovment;
    //private //PlayerLook playerLook;
    private TMP_Text nickname;
    
    [SerializeField] private GameObject camera;
    
    private void Start()
    {
        view = GetComponent<PhotonView>();
        //playerMovment = GetComponent<PlayerMovment>();
       // playerLook = GetComponent<PlayerLook>();
        
        if (view.IsMine)
        {
            camera.SetActive(true);
            //playerMovment.enabled = true;
            //playerLook.enabled = true;
        }
        else
        {
            camera.SetActive(false);
            //playerMovment.enabled = false;
            //playerLook.enabled = false;
        }

        try
        {
            nickname.text = PhotonNetwork.NickName;
        }
        catch {}
    }
}