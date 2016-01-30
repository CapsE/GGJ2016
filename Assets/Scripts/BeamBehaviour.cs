using UnityEngine;
using System.Collections;

public class BeamBehaviour : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider collider) {
        CowMotor cm = collider.gameObject.GetComponent<CowMotor>();
        if (cm) {
            cm.Abduct(transform);
        }
    }
}
