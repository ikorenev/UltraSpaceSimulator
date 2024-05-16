using System.Collections;
using System.Collections.Generic;
using System.Net.WebSockets;
using TMPro;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

namespace UltraSpaceSimulator
{
    [RequireComponent(typeof(LineRenderer))]
    public class Laser : MonoBehaviour,IWeapon
    {
        public bool CanFire;
        public float MaxDistance = 100.0f;
        public float DamageAmount = 5f;
        //public float TimeFiring = 0.25f;

        private Coroutine _coroutineFiring;
        private WaitForSeconds _waitForFiring;
        [SerializeField] private float waitTimeFiring = 0.3f;


        [Header("Links")]
        [SerializeField] private LineRenderer _lineRenderer;
        [SerializeField] private ShipWeapons _ShipWeapons;

        public List<IDamagable> TargetsHit = new List<IDamagable>();
        private void Awake()
        {
            if (_ShipWeapons == null)
                _ShipWeapons = GetComponentInParent<ShipWeapons>();
            if (_lineRenderer == null)
                _lineRenderer = GetComponent<LineRenderer>();
        }
        void Start()
        {
            _waitForFiring = new WaitForSeconds(waitTimeFiring);
            _lineRenderer.enabled = false;
            CanFire = true;
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
                    var damagableHit = TargetHit.GetComponent<IDamagable>();
                    if (damagableHit != null)
                    {
                        TargetsHit.Add(damagableHit);
                        Damage(DamageAmount, TargetHit.position, _ShipWeapons._ShipLinker.ShipAgent);
                    }
                    VisualizeFiring(TargetHit.position);

                    return TargetHit.position;
                }
                    
            }

            //If nothing was hit
            VisualizeFiring(transform.position + direction.normalized * MaxDistance);
            return TargetPosition;
            
        }
        public void Damage(float DamageAmount, Vector3 TargetHitPosition,GameAgent sender)
        {
            foreach (var TargetHit in TargetsHit)
            {
                TargetHit.ReciveDamage(DamageAmount, TargetHitPosition, sender);
            }
            TargetsHit.Clear();
        }
        public void VisualizeFiring(Vector3 TargetPosition)
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
