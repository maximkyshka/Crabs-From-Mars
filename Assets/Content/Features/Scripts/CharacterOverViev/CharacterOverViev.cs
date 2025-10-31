using Photon.Pun;
using UnityEngine;

public class CharacterOverViev : MonoBehaviour
{
    [Header("Charercter")]
    [SerializeField] private CharacterSetings characterSettings;
    
    [Header("MultyPlayer")]
    [SerializeField] private bool isMine;
    [SerializeField] private string nickName = "Djone";
    PhotonView view;

    [Header("Other")] 
    [SerializeField] private Transform model;

    
    private IMovement movement;
    private ICombat combat;
    private IHealse healse;

    private void Awake()
    {
        view = GetComponent<PhotonView>();
        isMine = view.IsMine;
        nickName = PhotonNetwork.NickName;
        Reload();
        
        movement = GetComponentInChildren<IMovement>();
        combat = GetComponentInChildren<ICombat>();
        healse = GetComponentInChildren<IHealse>();
    }
    
    [ContextMenu("Reload")]
    private void Reload()
    {
        
        if (model != null)
        {
            Destroy(model.GetComponentInChildren<GameObject>());
            Instantiate(characterSettings?.Model, model);
        }
    }
}
