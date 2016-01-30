using UnityEngine;
using System.Collections;

public class CowRotate : MonoBehaviour {


    public Vector3 rotateSpeed = new Vector3(1, 1, 0);

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.Rotate(rotateSpeed);
    }
}
