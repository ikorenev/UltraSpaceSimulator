using System.Collections;
using System.Collections.Generic;
using System.Net.WebSockets;
using TMPro;
using UnityEngine;

namespace UltraSpaceSimulator
{
    [RequireComponent(typeof(LineRenderer))]
    public class Laser : MonoBehaviour
    {
        public bool CanFire;
        public float MaxDistance = 100.0f;
        //public float TimeFiring = 0.25f;

        private Coroutine _coroutineFiring;
        private WaitForSeconds _waitForFiring;
        [SerializeField] private float waitTimeFiring = 0.3f;


        [Header("Links")]
        [SerializeField] private LineRenderer _lineRenderer;
        void Start()
        {
            if (_lineRenderer == null)
                _lineRenderer = GetComponent<LineRenderer>();

            _waitForFiring = new WaitForSeconds(waitTimeFiring);
            _lineRenderer.enabled = false;
            CanFire = true;
        }


        void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                Vector3 TargetPosition = FireWeapon(transform.position + transform.forward * MaxDistance);
                VisualizeFiringWeapon(TargetPosition);
            }
        }

    public Vector3 FireWeapon(Vector3 TargetPosition)
        {
            RaycastHit hitinfo;
            var direction  = TargetPosition - transform.position;
            if (Physics.Raycast(transform.position,direction,out hitinfo, MaxDistance))
            {
                var TargetHit = hitinfo.transform;
                if (TargetHit != null)
                {
                    //Debug.Log($" FireWeapon_TargetHit: {TargetHit.name}");
                    Destroy(TargetHit.gameObject);
                    return TargetHit.position;
                }
                    
            }

            //If nothing was hit
            return TargetPosition;
            
        }

        public void VisualizeFiringWeapon(Vector3 TargetPosition)
        {
            if (CanFire)
            {
                _lineRenderer.enabled = true;
                _lineRenderer.SetPosition(0, transform.position);
                _lineRenderer.SetPosition(1, TargetPosition);

                CanFire = false;

                _coroutineFiring = StartCoroutine(FiringCor());
            }
        }
        private IEnumerator FiringCor()
        {
            yield return _waitForFiring;
            CanFire = true;
            _lineRenderer.enabled = false;
        }
    }

}
