using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class UfoMotor : MonoBehaviour {

    public float upForce = 9.81f;
    public float upMax = 15.81f;
    public float upMin = -3.81f;
    public float mouseSpeed = 1;
    public float turnSpeed = 0.75f;
    public float turnTiltFactor = 0.1f;

    public float crashSpeed = 2;

    public float bonusGravity = 1;
    public GameObject explosion;
    public GameObject beam;

    public GameObject mainCam;
    public GameObject beamCam;

    private Rigidbody rb;
    private float currentForce;


    public float targetScale = 2.5f;
    public Vector3 growSpeed = new Vector3(0,0.0001f,0);
    bool grow = false;

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
            //beam.SetActive(true);
            //beamCam.SetActive(true);
            //mainCam.SetActive(false);
            grow = true;
        }
        if (Input.GetMouseButtonUp(0)) {
            grow = false;
            //beam.SetActive(false);
            //mainCam.SetActive(true);
            //beamCam.SetActive(false);
        }

        float a = transform.rotation.eulerAngles.z;
        if (a > 180) {
            a -= 360;
        }
        transform.Rotate(transform.up, -1 * (a * turnTiltFactor));


        if (grow && beam.transform.localScale.y < targetScale)
        {
            beam.transform.localScale += growSpeed;

        }
        else if (beam.transform.localScale.y > growSpeed.y)
        {
            beam.transform.localScale -= growSpeed;
        }
        else {
            beam.transform.localScale = new Vector3(beam.transform.localScale.x,0,beam.transform.localScale.z);
        }
    }

    void OnCollisionEnter(Collision collision) {
        if(collision.gameObject.tag == "Cow") {
            return;
        }
        if (collision.impulse.magnitude > crashSpeed) {
            mainCam.transform.parent = null;
            mainCam.SetActive(true);
            Instantiate(explosion, transform.position, Quaternion.identity);
            StartCoroutine(ChangeScene());
            Invoke("ChangeScene", 2.0f);
        }
    }

      IEnumerator ChangeScene()
      {
        yield return new WaitForSeconds(1);
        Destroy(gameObject);
        SceneManager.LoadScene(2);
      }

    void Grow()
    {
        grow = true;
    }
    

}
