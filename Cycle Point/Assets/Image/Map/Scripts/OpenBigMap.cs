using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class OpenBigMap : MonoBehaviour
{
	[SerializeField]
	//GameObject map;
	//GameObject map2;
	public GameObject MainEnd;
	public GameObject[] ArrayOfGameObjectsICareAbout;

	public bool enabled_map = false;
	void Start()
    {
        //map = GameObject.Find("Image");
		//map2 = GameObject.Find("MapTexture");
		ArrayOfGameObjectsICareAbout = new GameObject[4];
     	ArrayOfGameObjectsICareAbout[0] = GameObject.Find("Image");
		ArrayOfGameObjectsICareAbout[1] = GameObject.Find("MapTexture");
		ArrayOfGameObjectsICareAbout[2] = GameObject.Find("hot_keys_for_radar");
		ArrayOfGameObjectsICareAbout[3] = GameObject.Find("Contur");
		ArrayOfGameObjectsICareAbout[0].SetActive(false);
		ArrayOfGameObjectsICareAbout[1].SetActive(false);
		ArrayOfGameObjectsICareAbout[2].SetActive(false);
		
		MainEnd = GameObject.Find("Main End");
		MainEnd.SetActive(false);
	}
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && GameObject.Find("Controller").GetComponent<GeneralController>().is_Paused == false)
        {
			Debug.Log("click");
			Debug.Log(ArrayOfGameObjectsICareAbout.Length);
			if(ArrayOfGameObjectsICareAbout[0].activeSelf == true)
			{
				enabled_map = false;
				Debug.Log("true");
				//map.enabled = false;
				ArrayOfGameObjectsICareAbout[0].SetActive(false);
				ArrayOfGameObjectsICareAbout[1].SetActive(false);
				ArrayOfGameObjectsICareAbout[2].SetActive(false);
				ArrayOfGameObjectsICareAbout[3].SetActive(false);
			}
			else
			{
				enabled_map = true;
				Debug.Log("false");
				ArrayOfGameObjectsICareAbout[0].SetActive(true);
				ArrayOfGameObjectsICareAbout[1].SetActive(true);
				ArrayOfGameObjectsICareAbout[2].SetActive(true);
			}
		}
    }

	public void mainEnd()
    {
		SceneManager.LoadScene("Cutscene_main_ending");
    }
}
