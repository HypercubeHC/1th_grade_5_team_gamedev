using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamControl : MonoBehaviour
{
	[SerializeField]
	private Camera cam;
	public GameObject station;
	public GameObject contur;

	public float speedx = 0f, speedy = 0f;

	void Start()
    { 
        station = GameObject.Find("Cycle Point module M-01 (mini)");
		contur = GameObject.Find("radar without bg");
    }
    void Update()
		{
			if(contur.transform.position.x + speedx < -155.5 || contur.transform.position.x + speedx > -24.5)
				speedx = 0;
			if(contur.transform.position.y + speedy > 405)
			{
				cam.transform.position = new Vector3(cam.transform.position.x, -325.5f, cam.transform.position.z);
				station.transform.position = new Vector3(station.transform.position.x, -325.5f, station.transform.position.z);
				contur.transform.position = new Vector3(contur.transform.position.x, -325.5f, contur.transform.position.z);
			}
			if(contur.transform.position.y + speedy < -325.5)
			{
				cam.transform.position = new Vector3(cam.transform.position.x, 405, cam.transform.position.z);
				station.transform.position = new Vector3(station.transform.position.x, 405, station.transform.position.z);
				contur.transform.position = new Vector3(contur.transform.position.x, 405, contur.transform.position.z);
			}
			var dx = speedx;
			var dy = speedy;
			cam.transform.position = cam.transform.position + new Vector3(dx, dy, 0);
			station.transform.position = station.transform.position + new Vector3(dx, dy, 0);
			contur.transform.position = contur.transform.position + new Vector3(dx, dy, 0);
			if( Input.GetKeyDown( KeyCode.W ) )
            {
	            if(GameObject.Find("Controller").GetComponent<GeneralController>().fuelbar.fillAmount > 0.02 && speedy < 0.1f)
	            {
		            speedy += 0.01f;
		            GameObject.Find("Controller").GetComponent<GeneralController>().fuelbar.fillAmount -= 1 / 50f;//если нет топлива, то не ускоряется
	            }
            }
			if (Input.GetKeyDown(KeyCode.S))
			{
				if(GameObject.Find("Controller").GetComponent<GeneralController>().fuelbar.fillAmount > 0.02 && speedy > -0.1f)
				{
					speedy -= 0.01f;
					GameObject.Find("Controller").GetComponent<GeneralController>().fuelbar.fillAmount -= 1 / 50f;
				}
			}
			if( Input.GetKeyDown( KeyCode.A ) )
			{
				if(GameObject.Find("Controller").GetComponent<GeneralController>().fuelbar.fillAmount > 0.02 && speedx > -0.1f)
				{
					speedx -= 0.01f;
					GameObject.Find("Controller").GetComponent<GeneralController>().fuelbar.fillAmount -= 1 / 50f;
				}
			}
        	if( Input.GetKeyDown( KeyCode.D ) )
            {
	            if(GameObject.Find("Controller").GetComponent<GeneralController>().fuelbar.fillAmount > 0.02 && speedx < 0.1f)
	            {
					speedx += 0.01f;
					GameObject.Find("Controller").GetComponent<GeneralController>().fuelbar.fillAmount -= 1 / 50f;
				}
            }
	}
}