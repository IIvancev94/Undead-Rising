using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raycast : MonoBehaviour
{
    [SerializeField] Camera _FPCamera;
    [SerializeField] float _range = 100f;
    [SerializeField] float _damage = 30f;
    [SerializeField] GameObject _hitEffect;
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        RaycastHit _hit;
        if (Physics.Raycast(_FPCamera.transform.position, _FPCamera.transform.forward, out _hit, _range))
        {
            CreateHitImpact(_hit);
            Debug.Log("Pogodak" + _hit.transform.name);
            EnemyHealth target = _hit.transform.GetComponent<EnemyHealth>();
            if (target == null) return;
            target.TakeDamage(_damage);
        }
        else
        {
            return;
        }

    }

    private void CreateHitImpact(RaycastHit _hit)
    {
        GameObject impact = Instantiate(_hitEffect, _hit.point, Quaternion.LookRotation(_hit.normal));
        Destroy(impact, 1);
    }
}
