using System;
using UnityEngine;

[Serializable]
public class RunningStateConfig
{
    [field: SerializeField, Range(10, 20)] public float ChargeSpeed {  get; private set; }
    [field: SerializeField, Range(0, 10)] public float Speed { get; private set; }
    [field: SerializeField, Range(0, 10)] public float WalkSpeed { get; private set; }
}
