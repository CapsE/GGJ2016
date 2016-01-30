using UnityEngine;
using System.Collections;

public class CowShaker : MonoBehaviour {

    private float time = 0;
    private float timeB = 0;
    private Vector3 angles;

	// Use this for initialization
	void Start () {
        angles = new Vector3(0, 0, 0);
	}
	
	// Update is called once per frame
	void Update () {
        time += Time.deltaTime;
        timeB += Time.deltaTime;
        if (time > 0.125f) {
            time = 0;
            angles = new Vector3(Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f));
        }
        transform.Rotate(angles);
        if(timeB > 1) {
            timeB = 0;
            transform.rotation = transform.parent.rotation;
        }
	}
}
