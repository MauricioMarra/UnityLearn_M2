using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class TargetSphereControl : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawSphere(this.transform.position, GetComponent<SphereCollider>().radius);
    }
}
