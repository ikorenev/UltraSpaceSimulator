using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidHeath : MonoBehaviour,IDamagable
{
    public float Heath { get; }

    public void ReciveDamage(float damageAmount, Vector3 HitPosition, GameAgent sender)
    {
        Destroy(gameObject);
    }

    public void ReciveHeal(float healAmount, Vector3 HitPosition, GameAgent sender)
    {
        throw new System.NotImplementedException();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
