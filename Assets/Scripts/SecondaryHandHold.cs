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
    public GameObject glove;
    public GameObject highCollider;
    public GameObject lowCollider;

    public Renderer handRend;
    public Animator handAnim;

    public Material transparentHand;
    public Material solidHand;

    public AudioSource gripSound;
    void Start()
    {
        var avatar = VRAvatar.Active;
        if (avatar == null)
            return;
        canGrab = false;
        isHolding = false;
        //hand.transform.rotation = Quaternion.Euler(0, 0, 90);
        glove.GetComponent<Renderer>().material = transparentHand;
        highCollider.gameObject.SetActive(false);
        lowCollider.gameObject.SetActive(false);
    }


    void Update()
    {

        var device = VRDevice.Device;

        if (device.SecondaryInputDevice.GetButtonDown(VRButton.Three) || device.SecondaryInputDevice.GetButtonDown(VRButton.Trigger))
        {
            handAnim.SetTrigger("handClose");
            if (canGrab == true)
            {
              
                lever.GetComponent<Rigidbody>().isKinematic = true;
                isHolding = true;
                //rend.enabled = false;
                handRend.enabled = false;
                glove.GetComponent<Renderer>().material = solidHand;
                highCollider.gameObject.SetActive(true);
                lowCollider.gameObject.SetActive(true);
                gripSound.Play();
            }
        }


        if (device.SecondaryInputDevice.GetButtonUp(VRButton.Three) || device.SecondaryInputDevice.GetButtonUp(VRButton.Trigger))
        {
            handAnim.SetTrigger("handOpen");
            if (isHolding == true)
            {
                
                isHolding = false;
                lever.transform.parent = null;
                //rend.enabled = true;
                handRend.enabled = true;
                glove.GetComponent<Renderer>().material = transparentHand;
                highCollider.gameObject.SetActive(false);
                lowCollider.gameObject.SetActive(false);
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
            //hand.transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        canGrab = false;
        //hand.transform.rotation = Quaternion.Euler(0, 0, 90);
        
    }


}