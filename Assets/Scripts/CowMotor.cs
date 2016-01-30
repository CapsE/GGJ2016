using UnityEngine;
using System.Collections;

/// <summary>
/// Creates wandering behaviour for a CharacterController.
/// </summary>
[RequireComponent(typeof(CharacterController))]
public class CowMotor : MonoBehaviour
{
    public delegate void AbductedEventHandler(GameObject cow);
    public static event AbductedEventHandler AbductedEvent;

    public float speed = 5;
    public float directionChangeInterval = 1;
    public float maxHeadingChange = 30;
    public float abductSpeed = 0.25f;
    public GameObject moo;

    CharacterController controller;
    float heading;
    Vector3 targetRotation;
    private bool moving = true;
    private bool abducting = false;
    private Transform beam;

    void Awake()
    {
        controller = GetComponent<CharacterController>();

        // Set random initial rotation
        heading = Random.Range(0, 360);
        transform.eulerAngles = new Vector3(0, heading, 0);

        StartCoroutine(NewHeading());
    }

    void Update()
    {
        if (moving) {
            transform.eulerAngles = Vector3.Slerp(transform.eulerAngles, targetRotation, Time.deltaTime * directionChangeInterval);
            var forward = transform.TransformDirection(Vector3.forward);
            controller.SimpleMove(forward * speed);
        }

        if (abducting) {
            transform.position += ((beam.position + Vector3.up * (beam.localScale.y / 2)) - transform.position) * abductSpeed * Time.deltaTime;
        }
        
    }

    /// <summary>
    /// Repeatedly calculates a new direction to move towards.
    /// Use this instead of MonoBehaviour.InvokeRepeating so that the interval can be changed at runtime.
    /// </summary>
    IEnumerator NewHeading()
    {
        while (moving)
        {
            NewHeadingRoutine();
            yield return new WaitForSeconds(directionChangeInterval);
        }
    }

    /// <summary>
    /// Calculates a new direction to move towards.
    /// </summary>
    void NewHeadingRoutine()
    {
        var floor = Mathf.Clamp(heading - maxHeadingChange, 0, 360);
        var ceil = Mathf.Clamp(heading + maxHeadingChange, 0, 360);
        heading = Random.Range(floor, ceil);
        targetRotation = new Vector3(0, heading, 0);
    }

    public void Abduct(Transform beam) {
        if (!abducting) {
            Debug.Log("Abducting Cow");
            Instantiate(moo, transform.position, Quaternion.identity);
            if (CowMotor.AbductedEvent != null) {
                CowMotor.AbductedEvent(gameObject);
            }
            
            gameObject.GetComponent<BoxCollider>().isTrigger = true;
            gameObject.GetComponent<CharacterController>().enabled = false;
            moving = false;
            abducting = true;
            this.beam = beam;
        }

        
        
    }

    void OnTriggerEnter(Collider collider) {
        if(collider.gameObject.tag == "UFO") {
            Destroy(gameObject);
        }
        
    }
}