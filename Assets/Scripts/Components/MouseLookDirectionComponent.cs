using System;
using UnityEngine;

namespace Gyach.Source.Code.Ecs
{
    [Serializable]
    public struct MouseLookDirectionComponent
    {
        public Transform CameraTransform;
        [HideInInspector] public Vector3 Direction;
        public float MouseSensitivity;
        public float MaxAngle;
    }
}