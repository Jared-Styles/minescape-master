using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finish : MonoBehaviour
{
    //public Renderer rend;

    public Rigidbody leftPiece;
    public Rigidbody rightPiece;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "FinishBoard")
        {
            //TimerController.instance.EndTimer();
            //rend.enabled = false;
            leftPiece.isKinematic = true;
            rightPiece.isKinematic = true;
        }
    }
}
