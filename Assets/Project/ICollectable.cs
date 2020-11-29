using UnityEngine;

public interface ICollectable 
{
    CollectableSO OnCollect(); 
    bool IsCollected { get;}
}