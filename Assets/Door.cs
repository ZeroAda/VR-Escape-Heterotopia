using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class Door : MonoBehaviour
{

    public Transform DoorKai;

    public Transform guzi;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        DoorKai.DORotate(new Vector3(0,-90,0),1f);
        guzi.DORotate(new Vector3(0, -90, 0), 1f);

    }
}
