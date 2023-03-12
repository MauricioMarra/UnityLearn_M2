using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Bocha
{
    public class PlayerInput : MonoBehaviour
    {
        public float forceApplied;

        [SerializeField] private float multiplier;
        private float min = 0f;
        private float max = 5f;

        private bool isPressed;
        private Rigidbody rb;

        [SerializeField] private Slider slider;

        // Start is called before the first frame update
        void Start()
        {
            rb = GetComponent<Rigidbody>();
            //rb.maxAngularVelocity = 50f;
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                isPressed = true;
            }
            else if (Input.GetMouseButtonUp(0))
            {
                isPressed = false;
                //rb.AddTorque(forceApplied * multiplier, 0, 0, ForceMode.Impulse);
                rb.AddForce(0, 0, forceApplied * multiplier, ForceMode.Impulse);
            }

            if (isPressed)
                forceApplied += Time.deltaTime;
            else
                forceApplied = 0f;

            if (forceApplied > max)
                forceApplied = max;

            SetSlider();
        }

        public void SetSlider()
        {
            slider.value = Mathf.InverseLerp(this.min, this.max, this.forceApplied);
        }
    }
}
