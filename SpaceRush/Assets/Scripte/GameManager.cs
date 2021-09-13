using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public int rezultat = 0;
    private Text myText;
    public static int score;
    public Text text;
    //blic ParticleSystem explosion;

    void Start()
    {
        myText = GetComponent<Text>();
        Reset();
    }

    public void Rezultat(int points)
    {
        rezultat += points;
        myText.text = rezultat.ToString();
        score = rezultat;
        Debug.Log("Rezultat: " + rezultat);
    }
    /*
    public void MeteorDestroyed(Meteor meteor)
    {

        this.explosion.transform.position = meteor.transform.position;
        this.explosion.Play();
    }*/

    public void Reset()
    {
        rezultat = 0;
    }

}
