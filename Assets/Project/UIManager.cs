using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.InputSystem.InputAction;

public class UIManager : MonoBehaviour
{
    public GameObject InventoryUI;
    public GameObject ShipUI;


    private static UIManager mInstance;
    public static UIManager Instance { get { return mInstance;}}
    public bool InShipProximity { set;get;}
    
    void Start()
    {
        if(mInstance == null) mInstance = this;
    }

    public void ToggleInventory(CallbackContext ctx)
    {

        bool isActive = InventoryUI.activeSelf;
        InventoryUI.SetActive(!isActive);
    }
    public void ToggleRepairConsole(CallbackContext ctx)
    {
        if(!InShipProximity) return;
        ShipUI.SetActive(!ShipUI.activeSelf);
    }
}
