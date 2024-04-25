using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Engine : MonoBehaviour
{
    [SerializeField] private float _MoveSpeed = 0.5f;
    void Start()
    {
        
    }

    
    void Update()
    {
        
    }

    public Vector3 Thrust(){
     return  Vector3.forward * _MoveSpeed * Time.deltaTime;
    }
}
