using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MapObjects : MonoBehaviour
{
    [SerializeField]
    public GameObject[] ArrayOfGameObjects;
	public double[] destinations;

    void Start()
    {
        ArrayOfGameObjects = new GameObject[10];
		destinations = new double[9];
        ArrayOfGameObjects[0] = GameObject.Find("Cycle Point module M-01 (mini)"); //main module
        ArrayOfGameObjects[1] = GameObject.Find("Cycle Point module E-01 (mini)");
		ArrayOfGameObjects[2] = GameObject.Find("Cycle Point module E-02 (mini)");
        ArrayOfGameObjects[3] = GameObject.Find("Cycle Point module E-03 (mini)");
		ArrayOfGameObjects[4] = GameObject.Find("Cycle Point module E-04 (mini)");
        ArrayOfGameObjects[5] = GameObject.Find("Cycle Point module L-01 (mini)");
		ArrayOfGameObjects[6] = GameObject.Find("Cycle Point module M-02 (mini)");
        ArrayOfGameObjects[7] = GameObject.Find("Cycle Point module R-01 (mini)");
		ArrayOfGameObjects[8] = GameObject.Find("Cycle Point module R-02 (mini)");
        ArrayOfGameObjects[9] = GameObject.Find("Cycle Point module S-02 (mini)");
    }

    // Update is called once per frame
    void Update()
    {
        //float destination;
		for (int i = 1; i <= 9; i++)
		{
    		destinations[i - 1] = Mathf.Sqrt(Mathf.Pow((ArrayOfGameObjects[i].transform.position.x - ArrayOfGameObjects[0].transform.position.x), 2) +
                       Mathf.Pow((ArrayOfGameObjects[i].transform.position.y - ArrayOfGameObjects[0].transform.position.y), 2));
		}
		foreach(int destination in destinations)
		{
			if (destination < 30)
			{
				Debug.Log("The station is close");
				if (Input.GetKeyDown(KeyCode.E))
				{
					SceneManager.LoadScene("MiniGame", LoadSceneMode.Additive);
				}
			}
		}
        /*destination =
            Mathf.Sqrt(Mathf.Pow((ArrayOfGameObjects[1].transform.position.x - ArrayOfGameObjects[0].transform.position.x), 2) +
                       Mathf.Pow((ArrayOfGameObjects[1].transform.position.y - ArrayOfGameObjects[0].transform.position.y), 2));
        Debug.Log(destination);*/
    }
}
