using UnityEngine;
using System.Collections;

public class UfoMotor : MonoBehaviour {

    public float upForce = 9.81f;
    public float upMax = 15.81f;
    public float upMin = -3.81f;
    public float mouseSpeed = 1;
    public float turnSpeed = 0.1f;

    private Rigidbody rb;
    public float currentForce;

	// Use this for initialization
	void Start () {
        rb = gameObject.GetComponent<Rigidbody>();
        currentForce = upForce;
	}
	
	void FixedUpdate () {
        rb.AddForce(transform.up * currentForce);

    }

    void Update() {
        float h = mouseSpeed * Input.GetAxis("Mouse X");
        float v = mouseSpeed * Input.GetAxis("Mouse Y");
        transform.Rotate(Vector3.forward, -h);
        transform.Rotate(Vector3.left, -v);

        if (Input.GetKey(KeyCode.W)) {
            currentForce = upMax;
        }

        if (Input.GetKey(KeyCode.S)) {
            currentForce = upMin;
        }

        if (!Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.W)) {
            currentForce = upForce;
        }

        if (Input.GetKey(KeyCode.A)) {
            transform.Rotate(Vector3.up, -turnSpeed);
        }

        if (Input.GetKey(KeyCode.D)) {
            transform.Rotate(Vector3.up, turnSpeed);
        }
    }
}
