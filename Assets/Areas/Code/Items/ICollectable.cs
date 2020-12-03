using UnityEngine;

namespace ItLooksFamiliar.Items
{

    public interface ICollectable
    {
        CollectableSO OnCollect();
        bool IsCollected { set;get; }
    }
}