﻿using UnityEngine;

[System.Serializable]
public class VRMap2
{
    public Transform vrTarget;
    public Transform ikTarget;
    public Vector3 trackingPositionOffset;
    public Vector3 trackingRotationOffset;
    public void Map2()
    {
        ikTarget.position = vrTarget.TransformPoint(trackingPositionOffset);
        ikTarget.rotation = vrTarget.rotation * Quaternion.Euler(trackingRotationOffset);
    }
}

public class IKTargetFollowVRRig2 : MonoBehaviour
{
    [Range(0,1)]
    public float turnSmoothness = 0.1f;
    public VRMap2 head;
    public VRMap2 leftHand;
    public VRMap2 rightHand;
    //public VRMap1 leftLeg;
    //public VRMap1 rightLeg;

    public Vector3 headBodyPositionOffset;
    public float headBodyYawOffset;



    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = head.ikTarget.position + headBodyPositionOffset;
        //transform.position = initialPosition + headBodyPositionOffset;
        float yaw = head.vrTarget.eulerAngles.y;
        transform.rotation = Quaternion.Lerp(transform.rotation,Quaternion.Euler(transform.eulerAngles.x, yaw, transform.eulerAngles.z),turnSmoothness);

        head.Map2();
        leftHand.Map2();
        rightHand.Map2();

        //leftLeg.Map1();
        //rightLeg.Map1();

        head.ikTarget.position = head.ikTarget.position + new Vector3(35, 0, -1);
        leftHand.ikTarget.position = leftHand.ikTarget.position + new Vector3(35, 0, -1);
        rightHand.ikTarget.position = rightHand.ikTarget.position + new Vector3(35, 0, -1);
        //leftLeg.ikTarget.position = leftLeg.ikTarget.position + new Vector3(-10, 0,1);
        //rightLeg.ikTarget.position = rightLeg.ikTarget.position + new Vector3(-10, 0, 1);
    }
}
