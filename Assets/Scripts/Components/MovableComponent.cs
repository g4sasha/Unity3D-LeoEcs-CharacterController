using System;
using UnityEngine;

namespace Gyach.Source.Code.Ecs
{
    [Serializable]
    public struct MovableComponent
    {
        public CharacterController CharacterController;
        public float Speed;
    }
}