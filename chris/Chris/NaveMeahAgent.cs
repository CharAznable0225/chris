using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;

public class BulletManager : MonoBehaviour
{
    [Header("Exteral Scripts")]
    [SerializeField] private Camera Came;
    [SerializeField] private PlayerInput Inputs;

    [Header]("Bullets")
    [FormerlySerializedAs("BulletPrefab")]
    [SerializeField] private PhysicsBullet PhysicsBulletperfab;

    [Header("Raycast")]

    [SerializeField] private RaycastBullet BulletParticle;
    [SerializeField] private LayerMask RaycastMask;
    [SerializeField] private ShootType ShooingCalculation;

    public enum ShootType
    { 
        Raycast = 0,
        Physics = 1,
    }

    private void Update()
    {
        if (Inputs.Aim && Inputs.Fire) OnFirePressed();
        Inputs.Fire = false;
    }
}
