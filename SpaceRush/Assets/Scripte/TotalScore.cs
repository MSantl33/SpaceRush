using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TotalScore : MonoBehaviour {


    
    public Text text;
    // Use this for initialization
    void Start () {
        text = GameObject.Find("Canvas/Rezultat1").GetComponent<Text>();


        //text.text = GameManager.score.ToString();
        int recievedPoints = GameManager.score;
        text.text = recievedPoints.ToString();

    }

    public void Poimts()
    {
    }
	// Update is called once per frame
	void Update () {
	
	}
}
