using UnityEngine;
using System.Collections;

public class SelfieStick : MonoBehaviour {
	private GameObject player;
	private Vector3 armRotation;

	public float panSpeed = 10f;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag("Player");
		armRotation = transform.rotation.eulerAngles;
	}
	
	// Update is called once per frame
	void Update () {
		armRotation.y += Input.GetAxis("RHoriz") * panSpeed;
		armRotation.z = Input.GetAxis("RVert") * panSpeed;
		transform.position = player.transform.position;
		transform.rotation = Quaternion.Euler(armRotation);
	}
}
