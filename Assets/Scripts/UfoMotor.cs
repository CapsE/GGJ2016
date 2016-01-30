using UnityEngine;
using System.Collections;

public class UfoMotor : MonoBehaviour {

    public float upForce = 9.81f;
    public float upMax = 15.81f;
    public float upMin = -3.81f;
    public float mouseSpeed = 1;
    public float turnSpeed = 0.75f;
    public float turnTiltFactor = 0.1f;

    public float bonusGravity = 1;
    public GameObject explosion;
    public GameObject beam;

    public GameObject mainCam;
    public GameObject beamCam;

    private Rigidbody rb;
    private float currentForce;


    // Use this for initialization
    void Start() {
        rb = gameObject.GetComponent<Rigidbody>();
        currentForce = upForce + bonusGravity;

    }

    void FixedUpdate() {
        rb.AddForce(transform.up * currentForce);
        rb.AddForce(-1 * Vector3.up * bonusGravity);
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
            currentForce = upForce + bonusGravity;
        }

        if (Input.GetKey(KeyCode.A)) {
            transform.Rotate(transform.up, -turnSpeed);
        }

        if (Input.GetKey(KeyCode.D)) {
            transform.Rotate(transform.up, turnSpeed);
        }

        if (Input.GetMouseButtonDown(0)) {
            beam.SetActive(true);
            //beamCam.SetActive(true);
            //mainCam.SetActive(false);
        }
        if (Input.GetMouseButtonUp(0)) {
            beam.SetActive(false);
            //mainCam.SetActive(true);
            //beamCam.SetActive(false);
        }

        float a = transform.rotation.eulerAngles.z;
        if (a > 180) {
            a -= 360;
        }
        transform.Rotate(transform.up, -1 * (a * turnTiltFactor));
    }

    void OnCollisionEnter(Collision collision) {

        if (collision.impulse.magnitude > 1) {
            mainCam.transform.parent = null;
            mainCam.SetActive(true);
            Destroy(gameObject);
            Instantiate(explosion, transform.position, Quaternion.identity);
        }
    }
}
