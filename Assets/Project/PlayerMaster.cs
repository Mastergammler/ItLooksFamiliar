using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMaster : MonoBehaviour
{


    private IMoveable mMovement;
    // Start is called before the first frame update
    void Start()
    {
       mMovement = GetComponent<IMoveable>(); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void OnMove(InputAction.CallbackContext context)
    {
        Vector2 moveVal = context.ReadValue<Vector2>();
        mMovement.Move(moveVal); 
        //Debug.Log("Recieved movement input " + moveVal);
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        ICollectable col = other.GetComponent<ICollectable>();
        if(col != null)
        {
            CollectableSO so = col.OnCollect();
            Debug.Log("Collected Item: " + so.Name);
        }
        
    }

}
