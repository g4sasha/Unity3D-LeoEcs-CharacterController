using System;
using UnityEngine;

namespace Gyach.Source.Code.Ecs
{
    [Serializable]
    public struct GroundCheckSphereComponent
    {
        [HideInInspector] public bool IsGrounded;
        public Transform GroundCheckSphere;
        public LayerMask GroundMask;
        public float GroundDistance;
    }
}