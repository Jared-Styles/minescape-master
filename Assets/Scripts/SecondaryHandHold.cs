using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Liminal.SDK.VR.Avatars;
using Liminal.SDK.VR.Input;
using Liminal.SDK.VR;

public class SecondaryHandHold : MonoBehaviour
{
    private bool canGrab;
    private bool isHolding;
    public GameObject anchor;
    GameObject lever;
    public GameObject hand;
    public GameObject cubeCollider;
   

    void Start()
    {
        var avatar = VRAvatar.Active;
        if (avatar == null)
            return;
        canGrab = false;
        isHolding = false;
        hand.transform.rotation = Quaternion.Euler(0, 0, 90);
    }


    void Update()
    {

        var device = VRDevice.Device;

        if (device.SecondaryInputDevice.GetButtonDown(VRButton.Trigger))
        {
            if (canGrab == true)
            {
              
                lever.GetComponent<Rigidbody>().isKinematic = true;
                isHolding = true;
            }
        }


        if (device.SecondaryInputDevice.GetButtonUp(VRButton.Trigger))
        {
            if (isHolding == true)
            {
                
                isHolding = false;
                lever.transform.parent = null;
            }
        }

        /*if (device.SecondaryInputDevice.GetButtonDown(VRButton.Trigger))
         {
             Debug.Log("Secondary Trigger Press YAY");
             grab = true;
         }
         else
         {
             grab = false;
         } */
    }

    private void FixedUpdate()
    {
        if (isHolding == true)
        {
            
            lever.transform.position = new Vector3(lever.transform.position.x, anchor.transform.position.y, lever.transform.position.z);
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Handle1")
        {
            
            canGrab = true;
            lever = other.gameObject;
            hand.transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        canGrab = false;
        hand.transform.rotation = Quaternion.Euler(0, 0, 90);
        
    }


}