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
    PhotonView view;

    [Header("MultyPlayer")] 
    [SerializeField] private Transform model;
    
    [SerializeField] private GameObject PlayerControlerObject;
    private IMovement movement;
    private ICombat combat;
    private IHealse healse;

    private void Awake()
    {
        view = GetComponent<PhotonView>();
        isMine = view.IsMine;
        nickName = PhotonNetwork.NickName;
        
        movement = PlayerControlerObject.GetComponent<IMovement>();
        combat = PlayerControlerObject.GetComponent<ICombat>();
        healse = PlayerControlerObject.GetComponent<IHealse>();
        
        Reload();
    }
    
    [ContextMenu("Reload")]
    private void Reload()
    {
        if (movement != null && characterSettings != null)
        {
            movement.SpeedTurn = characterSettings.SpeedTurn;
            movement.SpeedWalk = characterSettings.SpeedWalk;
            movement.SpeedRun = characterSettings.SpeedRun;
            movement.SpeedCurve = characterSettings.SpeedCurve;
        }
        
        if (combat != null && characterSettings != null)
        {
            combat.HitDamage = characterSettings.HitDamage;
            combat.HitDamageSpeed = characterSettings.HitSpeed;
            combat.HitDamageRadius = characterSettings.HitRadius;
        }
        
        if (healse != null && characterSettings != null)
        {
            healse.MaxHealse = characterSettings.MaxHealth;
            healse.Healse = characterSettings.MaxHealth;
            healse.RegenerationSpeed = (int)characterSettings.RegenerationSpeed;
        }
        
        if (model != null && characterSettings != null)
        {
            Destroy(model.GetComponentInChildren<GameObject>());
            Instantiate(characterSettings.Model, model);
        }
    }
}
