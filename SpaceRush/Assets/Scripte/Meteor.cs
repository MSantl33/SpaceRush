using UnityEngine;
using System.Collections;

public class Meteor : MonoBehaviour {

    public Sprite[] sprites;
    public float vel = 1.0f;
    public float minVel = 0.5f;
    public float maxVel = 1.5f;
    public float brzina = 50.0f;
    public float maxVijek = 30.0f;
    public int rezultatValue = 100;

    public float steta = 100f;

    private SpriteRenderer sr;
    private Rigidbody2D rg;
    private GameManager prikazRezultata;

    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        rg = GetComponent<Rigidbody2D>();
    }
	// Use this for initialization
	void Start () {
        sr.sprite = sprites[Random.Range(0, sprites.Length)];
        this.transform.eulerAngles = new Vector3(0.0f, 0.0f, Random.value * 360.0f);
        this.transform.localScale = Vector3.one * this.vel;
        rg.mass = this.vel;
        prikazRezultata = GameObject.Find("Rezultat").GetComponent<GameManager>();

    }

    public void SetTrajectory(Vector2 smijer)
    {
        rg.AddForce(smijer * this.brzina);
        Destroy(this.gameObject, this.maxVijek);
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.tag == "bullet")
        {
            //FindObjectOfType<GameManager>().MeteorDestroyed(this);
            double x = System.Math.Pow(rg.mass,- 2) * rezultatValue;
            rezultatValue = (int)x;
            prikazRezultata.Rezultat(rezultatValue);
            Destroy(this.gameObject);

        }
    }

    public float GetDamage()
    {
        return steta*rg.mass;
    }

    
}
