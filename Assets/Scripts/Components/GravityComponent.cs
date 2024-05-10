using System;
using UnityEngine;

namespace Gyach.Source.Code.Ecs
{
    [Serializable]
    public struct GravityComponent
    {
        public float Gravity;
        [HideInInspector] public Vector3 Velocity;
    }
}