using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationFreeze : MonoBehaviour
{
    public Transform target;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(target.position.x, target.position.y, target.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(target.position.x-10.5f/10f, target.position.y+1.5f/10f, target.position.z-2.5f/10f);
        transform.RotateAround(target.transform.position, Vector3.up, target.transform.rotation.y);
        //transform.rotation = Quaternion.Euler(0, transform.eulerAngles.y, 0);

    }
}
