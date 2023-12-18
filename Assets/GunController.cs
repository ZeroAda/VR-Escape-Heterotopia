using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using DG.Tweening;
using System;

public class GunController : MonoBehaviour
{
   
    public Transform DoorKai;

    public Transform guzi;


    void Start()
    {
        XRGrabInteractable grabbable = GetComponent<XRGrabInteractable>();
       // grabbable.activated.AddListener(FireBullet);
        grabbable.selectEntered.AddListener(FireBullet);
    }

    private void FireBullet(SelectEnterEventArgs arg0)
    {
      
        guzi.DOLocalRotate(new Vector3(-90, 0, -90), 1f);
        DoorKai.DOLocalRotate(new Vector3(-90, 0, -90), 1f);
    }

    public void FireBulletdss()
    {
      
    }
}
