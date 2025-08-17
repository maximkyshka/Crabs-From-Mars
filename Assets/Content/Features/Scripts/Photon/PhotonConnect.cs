using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PhotonConnect : MonoBehaviourPunCallbacks
{
    [SerializeField] private TMP_InputField inputField;
    [SerializeField] private Button joinRoomButton;
    [SerializeField] private Button createRoomButton;
    
    [SerializeField] private int loadingScreen;

    private void Start()
    {
        Debug.Log("Connecting to Master...");
        PhotonNetwork.ConnectUsingSettings();

        joinRoomButton.interactable = false;
        createRoomButton.interactable = false;

        joinRoomButton.onClick.AddListener(JoinRoom);
        createRoomButton.onClick.AddListener(CreateRoom);
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("Connected to Master!");
        PhotonNetwork.JoinLobby();
    }

    public override void OnJoinedLobby()
    {
        Debug.Log("Joined Lobby!");
        joinRoomButton.interactable = true;
        createRoomButton.interactable = true;
    }

    private void CreateRoom()
    {
        if (string.IsNullOrEmpty(inputField.text))
        {
            return;
        }
        
        PhotonNetwork.CreateRoom(inputField.text, new RoomOptions { MaxPlayers = 6 });
    }

    private void JoinRoom()
    {
        if (string.IsNullOrEmpty(inputField.text))
        {
            return;
        }
        
        PhotonNetwork.JoinRoom(inputField.text);
    }

    public override void OnJoinedRoom()
    {
        Debug.Log("Joined Room: " + PhotonNetwork.CurrentRoom.Name);
        PhotonNetwork.LoadLevel(loadingScreen);
    }

    public override void OnJoinRoomFailed(short returnCode, string message)
    {
        Debug.LogError($"Join Room Failed: {message} (Code: {returnCode})");
    }

    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        Debug.LogError($"Create Room Failed: {message} (Code: {returnCode})");
    }
}