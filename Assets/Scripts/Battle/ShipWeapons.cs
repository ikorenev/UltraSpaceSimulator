using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class ShipWeapons : MonoBehaviour
{
    public SpaceShipLinker _ShipLinker;
    public List<IWeapon> Weapons = new List<IWeapon> ();

    public float MaxDistanceToTarget = 250f;

    private void Awake()
    {
           if (_ShipLinker == null ) 
            _ShipLinker = GetComponentInParent<SpaceShipLinker>();
        Weapons = GetComponentsInChildren<IWeapon>().ToList();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            FireWeapons ();
            
        }
    }
    public void FireWeapons()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));

        if(Physics.Raycast(ray, out hit, MaxDistanceToTarget))
        {
            foreach (var weapon in Weapons)
            {
                weapon.FireWeapon(hit.point);
               
            }
        }
        else
        {
            foreach (var weapon in Weapons)
            {
                weapon.FireWeapon(ray.origin + ray.direction * MaxDistanceToTarget);
                // weapon.FireWeapon(transform.position + transform.forward * MaxDistanceToTarget);

            }
        }
    }
}
