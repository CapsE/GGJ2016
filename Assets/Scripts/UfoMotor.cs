using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class UfoMotor : MonoBehaviour
{

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
    public Color beamColor;
    public Light spotlight;

    private Rigidbody rb;
    private float currentForce;

    private float runningTimer = 0;
    private float cooldownTimer = 0;


    public float targetScale = 2.5f;
    public Vector3 growSpeed = new Vector3(0, 0.0001f, 0);
    public Vector3 shrinkSpeed = new Vector3(0, 0.1f, 0);

    bool grow = false;
    

    // Use this for initialization
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        currentForce = upForce + bonusGravity;

    }

    void FixedUpdate()
    {
        rb.AddForce(transform.up * currentForce);
        rb.AddForce(-1 * Vector3.up * bonusGravity);
    }

    void Update()
    {
        float h = mouseSpeed * Input.GetAxis("Mouse X");
        float v = mouseSpeed * Input.GetAxis("Mouse Y");
        transform.Rotate(Vector3.forward, -h);
        transform.Rotate(Vector3.left, -v);

        if (Input.GetKey(KeyCode.W))
        {
            currentForce = upMax;
        }

        if (Input.GetKey(KeyCode.S))
        {
            currentForce = upMin;
        }

        if (!Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.W))
        {
            currentForce = upForce + bonusGravity;
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(transform.up, -turnSpeed);
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(transform.up, turnSpeed);
        }

        if (Input.GetMouseButtonDown(0) && cooldownTimer <= 0)
        {
            
                beam.SetActive(true);
                //beamCam.SetActive(true);
                //mainCam.SetActive(false);
                //mainCam.GetComponent<CameraSwitch>().Beam();
                grow = true;
                beam.GetComponent<AudioSource>().Play();            
            
        }
        if (Input.GetMouseButtonUp(0))
        {
            grow = false;
            //mainCam.GetComponent<CameraSwitch>().Normal();
            StartCoroutine(retractBeam());
            //mainCam.SetActive(true);
            //beamCam.SetActive(false);
        }
        if (Input.GetKeyDown(KeyCode.Escape)) {
            Application.Quit();
        }

        float a = transform.rotation.eulerAngles.z;
        if (a > 180)
        {
            a -= 360;
        }
        transform.Rotate(transform.up, -1 * (a * turnTiltFactor));


        if (grow && beam.transform.localScale.y < targetScale)
        {
            beam.transform.localScale += growSpeed;

        }
        else if (beam.transform.localScale.y > growSpeed.y)
        {
            beam.transform.localScale -= shrinkSpeed;
        }
        else
        {
            beam.transform.localScale = new Vector3(beam.transform.localScale.x, 0, beam.transform.localScale.z);
        }

        if (grow) {
            runningTimer += Time.deltaTime;
            float percent = runningTimer / 5;
            float percentB = 1 - percent;
            Color c = Color.red;
            Color newColor = new Color(percent * c.r + percentB * beamColor.r, percent * c.g + percentB * beamColor.g, percent * c.b + percentB * beamColor.b, beamColor.a);

            beam.GetComponent<Renderer>().material.color = newColor;
            beam.GetComponent<Renderer>().material.SetColor("_EmissionColor", newColor);
            spotlight.color = newColor;
            if (runningTimer > 5) {
                cooldownTimer = 3;
                grow = false;
                StartCoroutine(retractBeam());
                runningTimer = 0;
            }
        } else if(runningTimer >= 0){
            runningTimer -= Time.deltaTime;
        }
        if(cooldownTimer > 0) {
            cooldownTimer -= Time.deltaTime;
        } else if(grow == false) {
            spotlight.color = beamColor;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Cow")
        {
            return;
        }
        if (collision.impulse.magnitude > crashSpeed)
        {
            mainCam.transform.parent = null;
            mainCam.SetActive(true);
            Instantiate(explosion, transform.position, Quaternion.identity);
            StartCoroutine(ChangeScene());
        }
    }

    IEnumerator ChangeScene()
    {
        yield return new WaitForSeconds(2);
        Destroy(gameObject);
        SceneManager.LoadScene(2);
    }

    void Grow()
    {
        grow = true;
    }

    IEnumerator retractBeam()
    {
        yield return new WaitForSeconds(1.2f);
        beam.GetComponent<AudioSource>().Stop();
        beam.SetActive(false);
        beam.GetComponent<Renderer>().material.color = beamColor;
    }
    
}