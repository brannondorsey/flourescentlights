using UnityEngine;
using System.Collections;

public class Tunnel: MonoBehaviour
{
	public GameObject fixture;
	public int numbFixtures = 30;
	public int tunnelDepth = 5;
	public bool isGenerated = false;
	
	public Material onMat;
	public Material offMat;
	protected int i = 0;
	protected int j = 0;
	
	protected GameObject[,] fixtures;
	
	//dependent on numbFixtures and the size of each fixture
	protected int tunnelSize; 
	
	protected float tunnelRadius;
	protected float circumferance;
	protected float theta;
	protected float angleInc;
	protected float fixtureWidth;
	protected float fixtureDepth;
	
	// Use this for initialization
	void Start (){
		
		//GameObject cubeContainer = fixture.transform.Find("Collider").gameObject;
		//Debug.Log (cubeContainer);
		fixtureDepth = fixture.renderer.bounds.size.z;
		fixtureWidth = fixture.renderer.bounds.size.x;
		circumferance = fixtureWidth * numbFixtures;
		tunnelRadius = (circumferance/Mathf.PI)/2;
		angleInc = 360*Mathf.Deg2Rad/numbFixtures;
		
		theta = 0;
		float z = 0;
		
		fixtures = new GameObject[tunnelDepth, numbFixtures];
		
		for(int i = 0; i < tunnelDepth; i++){
			Debug.Log ("The size of fixtures is " + fixtures.Length.ToString());
			for(int j = 0; j < numbFixtures; j++){
				
				//Debug.Log(Mathf.Deg2Radtheta.ToString());
				
				// Convert polar to cartesian
			    float x = tunnelRadius * Mathf.Cos(theta); 
			    float y = tunnelRadius * Mathf.Sin(theta);
				
				fixtures[i, j] = (GameObject) Instantiate(fixture);
				fixtures[i, j].transform.position = new Vector3(x, y, z);
				fixtures[i, j].transform.Rotate(0, 0, theta*Mathf.Rad2Deg+90);
				fixtures[i, j].AddComponent("Fixture");
				Fixture temp = fixtures[i, j].GetComponent("Fixture") as Fixture;
				temp.construct(i, j, onMat, offMat);
				theta += angleInc;
				setFixtureState(i, j, false);
			}
			setFixtureState(i, 0, true);
			z += fixtureDepth;
		}
		
		Destroy(fixture);
		isGenerated = true;
	}
	
	// Update is called once per frame
	void Update (){
		if(Time.frameCount % 10 == 0){
			setFixtureState(i, j, true);
			Debug.Log ("Got Here");
			i++;
		}
		if(Time.frameCount % 2 == 0){
			setFixtureState(i, j, true);
			j++;
		}
		if(i == tunnelDepth) i = 0;
		if(j == numbFixtures) j = 0;
	}
	
	void setFixtureState(int i, int j, bool state){
		Fixture fixture = fixtures[i, j].GetComponent("Fixture") as Fixture;
		fixture.lightSwitch(state);
	}
	
	void switchAllLights(bool boolean){
		for(int i = 0; i < tunnelDepth; i++){
			for(int j = 0; j < numbFixtures; j++){
				setFixtureState(i, j, boolean);
			}
		}
	}
}

