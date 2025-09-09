using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SaveUserNick : MonoBehaviour
{
    [SerializeField] private TMP_Text userRoomNick;
    [SerializeField] private InputField userLobbyNick;
    private void SetNickName(InputField nickName)
    {
        userRoomNick.text = nickName.text;
    }
    private void Update()
    {
        SetNickName(userLobbyNick);
    }
}
