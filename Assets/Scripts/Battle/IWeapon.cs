using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public interface IWeapon 
{
    Vector3 FireWeapon(Vector3 TargetPosition);
    void Damage(float DamageAmount, Vector3 TargetHitPosition, GameAgent sender);
    void VisualizeFiring(Vector3 TargetPosition);
}
