using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamagable
{
    float Heath {  get; }
   void ReciveDamage(float damageAmount,Vector3 HitPosition, GameAgent sender);
   void ReciveHeal(float healAmount, Vector3 HitPosition, GameAgent sender);
}
