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

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("YellowSphere"))
            GameManager.instance.SetYellowScore(1);

        if (other.gameObject.CompareTag("BlueSphere"))
            GameManager.instance.SetBlueScore(1);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("YellowSphere"))
            GameManager.instance.SetYellowScore(-1);

        if (other.gameObject.CompareTag("BlueSphere"))
            GameManager.instance.SetBlueScore(-1);
    }
}
