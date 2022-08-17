using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Liminal.SDK.VR.Avatars;
using Liminal.SDK.VR.Input;
using Liminal.SDK.VR;

public class HoldObject : MonoBehaviour
{


    private bool canGrab;
    private bool isHolding;

    public GameObject anchor;
    GameObject lever;
    public GameObject glove;
    public GameObject highCollider;
    public GameObject lowCollider;

  
    public Renderer handRend;
    public Animator handAnim;
    
    public Material transparentHand;
    public Material solidHand;

    //public GameObject hand;
    //public GameObject cubeCollider;
    //public GameObject handEmpty;
    //public Renderer rend;
    //private Transform cachedHandPosition;
    //public GameObject handAnchor;

    void Start()
    {
        var avatar = VRAvatar.Active;
        if (avatar == null)
            return;
        canGrab = false;
        isHolding = false;
        //hand.transform.rotation = Quaternion.Euler(0, 0, -90);  
        glove.GetComponent<Renderer>().material = transparentHand;
        highCollider.gameObject.SetActive(false);
        lowCollider.gameObject.SetActive(false);
    }


    void Update()
    {

        var device = VRDevice.Device;
        //var rightHand = device.PrimaryHand;

        if (device.PrimaryInputDevice.GetButtonDown(VRButton.Three) || device.PrimaryInputDevice.GetButtonDown(VRButton.Trigger))
        {
            handAnim.SetTrigger("handClose");
            if (canGrab == true)
            {
                //lever.transform.parent = anchor.transform;
                //hand.transform.position = new Vector3 (0, anchor.transform.position.y, 0);
                lever.GetComponent<Rigidbody>().isKinematic = true;
                //glove.transform.parent = lever.transform;
                isHolding = true;
                //rend.enabled = false;
                handRend.enabled = false;
                glove.GetComponent<Renderer>().material = solidHand;
                highCollider.gameObject.SetActive(true);
                lowCollider.gameObject.SetActive(true);
            }
        }

      
        if (device.PrimaryInputDevice.GetButtonUp(VRButton.Three) || device.PrimaryInputDevice.GetButtonUp(VRButton.Trigger))
        {
            handAnim.SetTrigger("handOpen");
            if (isHolding == true)
            {
                //hand.transform.position = new Vector3(anchor.transform.position.x, anchor.transform.position.y, anchor.transform.position.z);
                isHolding = false;
                lever.transform.parent = null;
                //rend.enabled = true;
                //glove.transform.parent = hand.transform;
                handRend.enabled = true;
                glove.GetComponent<Renderer>().material = transparentHand;
                highCollider.gameObject.SetActive(false);
                lowCollider.gameObject.SetActive(false);
            }
        }

        /* if (device.SecondaryInputDevice.GetButtonDown(VRButton.Trigger))
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
            //hand.transform.position = new Vector3(0, anchor.transform.position.y, 0);
            lever.transform.position = new Vector3(lever.transform.position.x, anchor.transform.position.y, lever.transform.position.z);
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Handle1")
        {
            //storeHandPos();
            //cachedHandPosition = new Vector3(anchor.transform.position.x, anchor.transform.position.y, anchor.transform.position.z);
            //cachedHandPosition.position = anchor.transform.position;
            canGrab = true;
            lever = other.gameObject;
            //hand.transform.rotation = Quaternion.Euler(0,0,0);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        canGrab = false;
        //hand.transform.rotation = Quaternion.Euler(0, 0, -90);
        //isHolding = false;
    }

    void storeHandPos()
    {
        //cachedHandPosition.position = anchor.transform.position;
        //Debug.Log(cachedHandPosition);
    }
}