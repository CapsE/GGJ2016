using UnityEngine;
using System.Collections;

public class UfoMotor : MonoBehaviour {

    public float upForce = 1;

    private Rigidbody rb;

	// Use this for initialization
	void Start () {
        rb = gameObject.GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        rb.AddForce(Vector3.up * upForce);
	}
}
