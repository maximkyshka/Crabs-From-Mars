using Photon.Pun;
using TMPro;
using UnityEngine;

public class CharacterOverViev : MonoBehaviour
{
    [Header("Charercter")]
    [SerializeField] private CharacterSetings characterSettings;
    
    [Header("MultyPlayer")]
    [SerializeField] private bool isMine;
    [SerializeField] private string nickName = "Djone";
    [SerializeField] private TMP_Text textNickName;
    PhotonView view;

    [Header("MultyPlayer")] 
    [SerializeField] private Transform model;
    
    private Character character;

    private void Awake()
    {
        view = GetComponent<PhotonView>();
        isMine = view.IsMine;
        textNickName.text = PhotonNetwork.NickName;
        Reload();
    }
    
    [ContextMenu("Reload")]
    private void Reload()
    {
        if (textNickName != null)
        {
            textNickName.text = nickName;
        }
        
        if (model != null)
        {
            Destroy(model.GetComponentInChildren<GameObject>());
            Instantiate(characterSettings?.Model, model);
        }
        
        character.Instantiate(characterSettings);
    }
}
