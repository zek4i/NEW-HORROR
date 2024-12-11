using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpScare : MonoBehaviour
{
    public GameObject jumpscareObject;
    //use another approach maybe where we create a camera used for just jumpscare in the face ig??

    private void Start()
    {
        jumpscareObject.SetActive(false);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            jumpscareObject.SetActive(true);
        }
    }
}
