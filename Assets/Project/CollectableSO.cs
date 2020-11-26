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
    public float Stability;
    public float Conductivity;
}