using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New collectable",menuName = "Collectable")]
public class CollectableSO : ScriptableObject
{
    public string ID { get; } = System.Guid.NewGuid().ToString();
    public Sprite Image;
    public string Name;
    [Multiline]
    public string Description;

    public float ThermalConductivity;
    public float IsolationValue;
    public float PressureResistance;
    public float ElectricalConductivity;
    public float VibrationValue;
}