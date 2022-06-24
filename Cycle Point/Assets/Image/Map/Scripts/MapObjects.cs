using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MapObjects : MonoBehaviour
{
    [SerializeField]
    public GameObject[] ArrayOfGameObjects;
	public double[] destinations;
    public int ind;
    int ind2;

    void Start()
    {
        ArrayOfGameObjects = new GameObject[10];
		destinations = new double[9];
        ArrayOfGameObjects[0] = GameObject.Find("Cycle Point module M-01 (mini)"); //main module
        ArrayOfGameObjects[1] = GameObject.Find("Module E-01 (mini)");
		ArrayOfGameObjects[2] = GameObject.Find("Module E-02 (mini)");
        ArrayOfGameObjects[3] = GameObject.Find("Module E-03 (mini)");
		ArrayOfGameObjects[4] = GameObject.Find("Module E-04 (mini)");
        ArrayOfGameObjects[5] = GameObject.Find("Module L-01 (mini)");
		ArrayOfGameObjects[6] = GameObject.Find("Module M-02 (mini)");
        ArrayOfGameObjects[7] = GameObject.Find("Module R-01 (mini)");
		ArrayOfGameObjects[8] = GameObject.Find("Module R-02 (mini)");
        ArrayOfGameObjects[9] = GameObject.Find("Module S-02 (mini)");
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
        ind2 = 0;
		foreach(int destination in destinations)
		{
			if (destination < 30)
			{
				Debug.Log("The station is close");
				if (Input.GetKeyDown(KeyCode.Q) && isCorrect())
				{
                    ind = ind2;
                    SceneManager.LoadScene("MiniGame", LoadSceneMode.Additive);
                    break;
				}
			}
            ++ind2;
        }
        /*destination =
            Mathf.Sqrt(Mathf.Pow((ArrayOfGameObjects[1].transform.position.x - ArrayOfGameObjects[0].transform.position.x), 2) +
                       Mathf.Pow((ArrayOfGameObjects[1].transform.position.y - ArrayOfGameObjects[0].transform.position.y), 2));
        Debug.Log(destination);*/
    }

    bool isCorrect ()
    {
        if (ArrayOfGameObjects[ind2+1].name == "Module E-04 (mini)" && !GameObject.Find("Module L-01").activeSelf)
            return false;
        if (ArrayOfGameObjects[ind2 + 1].name == "Module E-03 (mini)" && !GameObject.Find("Module E-02").activeSelf)
            return false;
        if (ArrayOfGameObjects[ind2 + 1].name == "Module S-02 (mini)" && !GameObject.Find("Module E-02").activeSelf)
            return false;
        if (ArrayOfGameObjects[ind2 + 1].name == "Module R-02 (mini)" && !GameObject.Find("Module E-03").activeSelf)
            return false;
        if (ArrayOfGameObjects[ind2 + 1].name == "Module M-02 (mini)" && !GameObject.Find("Module E-01").activeSelf)
            return false;
        return true;
    }
}
