using UnityEngine;
using System.Collections;

public class TunnelGenerator : MonoBehaviour
{
	public GameObject fixture;
	public int numbFixtures = 30;
	public int tunnelDepth = 5;
	
	protected GameObject[] fixtures;
	
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
		
		fixtures = new GameObject[numbFixtures*tunnelDepth];
		
		for(int depth = 0; depth < tunnelDepth; depth++){
			
			for(int i = 0; i < fixtures.Length/tunnelDepth; i++){
				
				//Debug.Log(Mathf.Deg2Radtheta.ToString());
				
				// Convert polar to cartesian
			    float x = tunnelRadius * Mathf.Cos(theta); 
			    float y = tunnelRadius * Mathf.Sin(theta);
				
				fixtures[i+depth] = (GameObject) Instantiate(fixture);
				fixtures[i+depth].transform.position = new Vector3(x, y, z);
				fixtures[i+depth].transform.Rotate(0, 0, theta*Mathf.Rad2Deg+90);
				theta += angleInc;
			}
			
			z += fixtureDepth;
		}
		
		Destroy(fixture);
	}
	
	// Update is called once per frame
	void Update (){
	
	}
}

