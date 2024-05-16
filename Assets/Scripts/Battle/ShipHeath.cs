using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipHeath : MonoBehaviour, IDamagable
{
    [SerializeField] private float _heath = 10;
    public float Heath => _heath;
    private void Start()
    {
        
    }

    public void ReciveDamage(float damageAmount, Vector3 HitPosition, GameAgent sender)
    {
        _heath -= damageAmount;
        if (_heath < 0)
        {
            //Debug.Log($"Attañker: {sender.gameObject.name}");
            //Debug.Log($"Attañker faction: {sender.ShipFaction}");
            Destroy(gameObject);
        }
    }

    public void ReciveHeal(float healAmount, Vector3 HitPosition, GameAgent sender)
    {
        throw new System.NotImplementedException();
    }

}
