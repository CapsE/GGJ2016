﻿using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
    
	// Update is called once per frame
	void Update () {
	
	}

    public void StartButton() {
        SceneManager.LoadScene(1);
        Cursor.visible = false;
    }
}
