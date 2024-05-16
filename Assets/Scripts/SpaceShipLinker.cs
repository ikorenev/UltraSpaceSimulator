using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceShipLinker : MonoBehaviour
{
    public GameAgent ShipAgent;
    // Start is called before the first frame update
    private void Awake()
    {
        if (ShipAgent == null)
            ShipAgent = gameObject.AddComponent<GameAgent>();
    }
 

}
