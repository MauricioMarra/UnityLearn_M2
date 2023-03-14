using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Bocha
{
    public class PlayerInput : MonoBehaviour
    {
        public float forceApplied;

        [SerializeField] private GameObject guide;
        [SerializeField] private float multiplier;
        [SerializeField] private GameObject spawnPoint;

        private float min = 0f;
        private float max = 5f;

        private bool isPressed;
        private bool canManipulateSphere = true;
        private Rigidbody rb;

        // Start is called before the first frame update
        void Start()
        {
            rb = GetComponent<Rigidbody>();
            //rb.maxAngularVelocity = 50f;
            spawnPoint = GameObject.Find("SpawnPoint");
        }

        // Update is called once per frame
        void Update()
        {
            if (canManipulateSphere)
            {
                MouseToWorld();

                if (Input.GetMouseButtonDown(0))
                {
                    isPressed = true;
                }
                else if (Input.GetMouseButtonUp(0))
                {
                    isPressed = false;
                    //rb.AddTorque(forceApplied * multiplier, 0, 0, ForceMode.Impulse);
                    rb.AddRelativeForce(0, 0, forceApplied * multiplier, ForceMode.Impulse);
                    canManipulateSphere = false;
                    guide.SetActive(false);
                    GameManager.instance.ReadyNextPlayer();
                }

                if (isPressed)
                    forceApplied += Time.deltaTime;
                else
                    forceApplied = 0f;

                if (forceApplied > max)
                    forceApplied = max;
            
                SetSlider();
            }

        }

        private void MouseToWorld()
        {
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            Physics.Raycast(ray, out var hitInfo, Mathf.Infinity);

            var direction = hitInfo.point - ray.origin;

            Debug.DrawRay(ray.origin, direction, Color.red);
            Debug.DrawLine(spawnPoint.transform.position, hitInfo.point, Color.green);

            guide.transform.position = hitInfo.point;

            this.transform.LookAt(guide.transform.position);
        }

        public void SetSlider()
        {
            var value = Mathf.InverseLerp(this.min, this.max, this.forceApplied);
            GameManager.instance.SetPowerSlider(value);
        }
    }
}
