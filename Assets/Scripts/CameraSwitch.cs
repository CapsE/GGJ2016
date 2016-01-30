using UnityEngine;
using System.Collections;

public class CameraSwitch : MonoBehaviour {

    public Transform endPosition;
    public Transform startPosition;
    public float speed = 1;
    public float duration = 0.5f;
   
    private Moving moving;
    enum Moving { not, beam, normal };

    // Use this for initialization
    void Start () {
        moving = Moving.not;
	}
	
	// Update is called once per frame
	void Update () {
        if (moving == Moving.beam) {
            transform.position = Vector3.Lerp(transform.position, endPosition.position, speed);
            if (transform.rotation.x < endPosition.rotation.x) {
                transform.Rotate(Vector3.left, -1 * (endPosition.rotation.x - transform.rotation.x) * speed * 100);
            }
        }else if( moving == Moving.normal) {
            transform.position = Vector3.Lerp(transform.position, startPosition.position, speed);
            if (transform.rotation.x > startPosition.rotation.x) {
                transform.Rotate(Vector3.left, -1 * (startPosition.rotation.x - transform.rotation.x) * speed * 100);
            }
            
        }
	}

    public void Beam() {
        moving = Moving.beam;
    }

    public void Normal() {
        moving = Moving.normal;
    }
}
