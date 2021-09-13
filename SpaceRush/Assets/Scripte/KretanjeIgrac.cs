using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class KretanjeIgrac : MonoBehaviour {


    private bool ubrzavanje;
    private bool usporavanje;
    private float turnDirection;
    public float brzina = 3f;
    public float brzinaOkretanja = 0.15f;
    private float brzinaProjektila = 500.0f;
    private float maxVrijemeBullet = 10.0f;

    public float snaga = 300f;

    public GameObject projektil;
    private Rigidbody2D rg;


    // Use this for initialization
    void Start () {

        rg = GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void Update () {

        ubrzavanje = Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow);
        usporavanje = Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow);


        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            turnDirection = 1.0f;
        }
        else if(Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            turnDirection = -1.0f;
        }
        else
        {
            turnDirection = 0.0f;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            
            GameObject bullet = Instantiate(this.projektil, this.transform.position, this.transform.rotation) as GameObject;
            bullet.GetComponent<Rigidbody2D>().AddForce(this.transform.up * brzinaProjektila);
            Destroy(bullet, this.maxVrijemeBullet);
        }

        
	}
    private void FixedUpdate()
    {
        if (ubrzavanje)
        {
            rg.AddForce(this.transform.up * this.brzina);
        }
        if (usporavanje)
        {
            var trenutnaBrzina = rg.velocity.magnitude;
            var novaBrzina = trenutnaBrzina -5* Time.deltaTime;
            if (novaBrzina < 0)
            {
                novaBrzina = 0;
            }
            rg.velocity = rg.velocity.normalized * novaBrzina;
        }
        if (turnDirection != 0)
        {
            rg.AddTorque(turnDirection * this.brzinaOkretanja);
        }

    }
    
    void OnCollisionEnter2D(Collision2D collision)
    {
        Meteor meteor = collision.gameObject.GetComponent<Meteor>();
        if (collision.gameObject.tag=="meteor")
        {
            snaga -= meteor.GetDamage();
            if (snaga <= 0)
            {
                Destroy(this.gameObject);
                Application.LoadLevel("Win");
            }
        }
    }
    

}
