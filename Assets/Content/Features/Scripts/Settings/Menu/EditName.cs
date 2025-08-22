using System;
using UnityEngine;
using TMPro;
using Photon.Pun;

public class EditName : MonoBehaviour
{
    [SerializeField] private TMP_Text nameText;
    [SerializeField] private TMP_InputField inputField;

    void Start()
    {
        nameText.text = "Name: " + GetPlayerName();

        inputField.text = GetPlayerName();
        inputField.onEndEdit.AddListener(SaveName);
        
        PhotonNetwork.NickName = GetPlayerName();
    }
    private void SaveName(string newName)
    {
        PlayerPrefs.SetString("PlayerName", newName);
        nameText.text = "Name: " + newName;
        PlayerPrefs.Save();
    }
    
    String GetPlayerName()
    {
        String name;
        name = PlayerPrefs.GetString("PlayerName", "-1");
        if (name == "-1") name = System.Environment.UserName;
        return name;
    }
}