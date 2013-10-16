using UnityEngine;
using System.Collections;

public class TunnelGenerator : MonoBehaviour
{
	public GameObject fixture;
	public int numbFixtures = 30;
	
	protected GameObject[] fixtures;
	
	//dependent on numbFixtures and the size of each fixture
	protected int tunnelSize; 
	
	protected float tunnelRadius;
	protected float circumferance;
	protected float theta;
	protected float angleInc;
	protected float fixtureWidth;
	
	// Use this for initialization
	void Start (){
		
		//GameObject cubeContainer = fixture.transform.Find("Collider").gameObject;
		//Debug.Log (cubeContainer);
		
		fixtureWidth = fixture.renderer.bounds.size.x;
		circumferance = fixtureWidth * numbFixtures;
		tunnelRadius = (circumferance/Mathf.PI)/2;
		angleInc = 360*Mathf.Deg2Rad/numbFixtures;
		
		theta = 0;
		
		fixtures = new GameObject[numbFixtures];
		for(int i = 0; i < fixtures.Length; i++){
			
			//Debug.Log(Mathf.Deg2Radtheta.ToString());
			
			// Convert polar to cartesian
		    float x = tunnelRadius * Mathf.Cos(theta); 
		    float y = tunnelRadius * Mathf.Sin(theta);
			
			fixtures[i] = (GameObject) Instantiate(fixture);
			fixtures[i].transform.position = new Vector3(x, y, 0);
			fixtures[i].transform.Rotate(0, 0, theta*Mathf.Rad2Deg+90);
			theta += angleInc;
		}
		
		Destroy(fixture);
	}
	
	// Update is called once per frame
	void Update (){
	
	}
}

