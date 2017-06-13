using UnityEngine;
using System.Collections;

public class Make : MonoBehaviour {

	// Use this for initialization
	public GameObject targetStartObject;
	public GameObject targetEndObject;
	public GameObject cloneObject;
	public  int nCount = 5;
	public float fWidth = 0.3f;
	public float fWeight = 0.4f;
	public float fDrag = 1.0f;
	public float fAngDrag = 0.5f;
	public float temp1 = 0.7f;
	public float temp2 = 10.0f;
	private GameObject prevObj;
	void Start () {
		int i;
		
		for(i = 0 ; i< nCount ;i++){
			GameObject temp;
			temp = (GameObject)Instantiate(cloneObject);
			temp.name = "JointObj" + i;
			Vector3 vecDir = targetEndObject.transform.position - targetStartObject.transform.position;
			//temp.transform.position = Vector3.Lerp(targetStartObject.transform.position, targetEndObject.transform.position, (float)i / nCount);
			temp.transform.position = targetStartObject.transform.position + vecDir.normalized * fWidth * i * 1.2f;
			temp.transform.eulerAngles = new Vector3(0, 0, 0);
			temp.transform.localScale = new Vector3(fWidth, fWidth, fWidth);
			temp.transform.parent = targetStartObject.transform;
			if(i == 0){
				temp.GetComponent<Rigidbody>().isKinematic = true;
				temp.GetComponent<Rigidbody>().mass = fWeight;
			}
			else{
				temp.GetComponent<Rigidbody>().mass = prevObj.GetComponent<Rigidbody>().mass * temp1;
				temp.GetComponent<Rigidbody>().drag = fDrag;
				temp.GetComponent<Rigidbody>().angularDrag = fAngDrag;
				temp.GetComponent<HingeJoint>().connectedBody = prevObj.GetComponent<Rigidbody>();
//				temp.rigidbody.constraints = RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotationX;
			}
			prevObj = temp;
		}
		targetEndObject.GetComponent<Renderer>().enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.A))
		{
			prevObj.GetComponent<Rigidbody>().AddForce(Random.insideUnitSphere.normalized*temp2);
		}
	}
}
