using UnityEngine;
using System.Collections;

public class ReplaySystem : MonoBehaviour {
	private const int bufferFrames = 100;
	private MyKeyFrame[] keyFrames = new MyKeyFrame [bufferFrames];
	private Rigidbody rigidBody;
	private GameManager gameManager;
	// Use this for initialization
	void Start () {
		rigidBody = GetComponent<Rigidbody>();
		gameManager = GameObject.FindObjectOfType<GameManager>();
		}
	
	// Update is called once per frame
	void Update () {
		if(gameManager.recording){
			Record();
		} else{
			Playback();
		}
	}
	void Record(){
		int frame = Time.frameCount % bufferFrames;
		float time = Time.time;
		keyFrames[frame] = new MyKeyFrame(time, transform.position, transform.rotation);
	}
	void Playback(){
		rigidBody.isKinematic = true;
		int frame = Time.frameCount % bufferFrames;
		transform.position = keyFrames[frame].position;
		transform.rotation = keyFrames[frame].rotation;
	}
}
/// <summary>
/// A structure for storing time, position and rotation
/// </summary>
public class MyKeyFrame{
	public float frameTime;
	public Vector3 position;
	public Quaternion rotation;
	public MyKeyFrame(float aTime, Vector3 aPos, Quaternion aRot){
		frameTime = aTime;
		position = aPos;
		rotation = aRot;
	}
}