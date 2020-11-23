using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour {

	public GameObject NormCam;
	public GameObject HoodCam;
	public GameObject TopCam;
	public GameObject RightCam;
	public GameObject LeftCam;

	public int currentCam;

	// Use this for initialization
	void Start () {
		currentCam = 1;
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown (KeyCode.C)) {
			currentCam++;

			if (currentCam > 5) {
				currentCam = 1;
			}
		}

		switch (currentCam) {
		case 1:
			NormCam.SetActive (true);
			HoodCam.SetActive (false);
			TopCam.SetActive (false);
			RightCam.SetActive (false);
			LeftCam.SetActive (false);
			break;
		case 2:
			NormCam.SetActive (false);
			HoodCam.SetActive (true);
			TopCam.SetActive (false);
			RightCam.SetActive (false);
			LeftCam.SetActive (false);
			break;
		case 3:
			NormCam.SetActive (false);
			HoodCam.SetActive (false);
			TopCam.SetActive (true);
			RightCam.SetActive (false);
			LeftCam.SetActive (false);
			break;
		case 4:
			NormCam.SetActive (false);
			HoodCam.SetActive (false);
			TopCam.SetActive (false);
			RightCam.SetActive (true);
			LeftCam.SetActive (false);
			break;
		case 5:
			NormCam.SetActive (false);
			HoodCam.SetActive (false);
			TopCam.SetActive (false);
			RightCam.SetActive (false);
			LeftCam.SetActive (true);
			break;
		}

	}
}
