using Photon.Pun;
using TMPro;
using UnityEngine;

public class IsMine : MonoBehaviour
{
    private PhotonView view;
    private RobotControler robotControler;
    private TMP_Text nickname;
    
    [SerializeField] private GameObject camera;
    
    private void Start()
    {
        view = GetComponent<PhotonView>();
        robotControler = GetComponent<RobotControler>();
        
        if (view.IsMine)
        {
            camera.SetActive(true);
            robotControler.enabled = true;
        }
        else
        {
            camera.SetActive(false);
            robotControler.enabled = false;
        }

        try
        {
            nickname.text = PhotonNetwork.NickName;
        }
        catch {}
    }
}
