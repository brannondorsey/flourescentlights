using UnityEngine;
using System.Collections;

public class Fixture : MonoBehaviour {
	
	public int i; //tunnel segment
	public int j; //jth fixture in tunnel segment
	public Material onMat;
	public Material offMat;
	public GameObject lightObj;
	
	protected bool on = true;
	
	public void construct(int _i, int _j, Material _onMat, Material _offMat){
		i = _i;
		j = _j;
		onMat = _onMat;
		offMat = _offMat;
	}
	
	public void lightSwitch(bool boolean){
		if(on != boolean){
			on = boolean;
			simulateSwitch(boolean);
		}
	}
	
	public bool isOn(){
		return on;
	}
	
	// Use this for initialization
	void Start () {
		on = false;
	}
	
	// Update is called once per frame
	void Update () {

	}
	
	protected void simulateSwitch(bool isOn){
		Material mat;
		GameObject leftBulb = transform.Find("Light/Left Bulb").gameObject;
		GameObject rightBulb = transform.Find("Light/Right Bulb").gameObject;
		Debug.Log("Light is " + isOn.ToString());
		if(isOn){
			//code to simulate light on
			leftBulb.renderer.material = onMat;
			rightBulb.renderer.material = onMat;
			//lightObj = new GameObject("Point Light");
			//lightObj.AddComponent<Light>();
			//lightObj.light.type = LightType.Spot;
			//lightObj.transform.position = new Vector3(transform.position.x-1,
													  //transform.position.y,
													  //transform.position.z);
			//lightObj.transform.Rotate(0, 90, 0);
		}else{
			//code to simulate light off
			Destroy(light);
			Debug.Log("I should be OFF");
			leftBulb.renderer.material = offMat;
			rightBulb.renderer.material = offMat;
		}
	}

}
