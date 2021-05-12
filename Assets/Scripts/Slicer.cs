using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using BzKovSoft.ObjectSlicer;
using BzKovSoft.ObjectSlicerSamples;
public class Slicer : MonoBehaviour
{
    [SerializeField] private GameObject blade;
    [SerializeField] private GameObject searchPoint;
    [SerializeField] private float duration;
    [SerializeField] private float offsetY;

    private BzKnife knife;
    float timer;

    private void Start()
    {
        knife = blade.GetComponent<BzKnife>();
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && timer < 0)
        {
            timer = duration;
            knife.BeginNewSlice();
            blade.transform.DOMoveY(blade.transform.position.y - offsetY, duration / 2).SetLoops(2, LoopType.Yoyo);
            //Collider[] colliders = Physics.OverlapSphere(searchPoint.transform.position, 3);
            //foreach (var coll in colliders)
            //{
            //    Rigidbody rb = coll.GetComponent<Rigidbody>();
            //    if (rb)
            //        rb.AddForce(transform.forward * 100);
            //    print(rb.name);
            //}
        }
        else
        {
            timer -= Time.deltaTime;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawSphere(searchPoint.transform.position, 3);
    }
}
