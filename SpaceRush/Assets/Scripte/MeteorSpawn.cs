using UnityEngine;
using System.Collections;
using System;

public class MeteorSpawn : MonoBehaviour {

    public float spawnRate = 1.3f;
    public float spawnDaljina = 15.0f;
    public int spawnKoličina = 1;
    public float varijancaPutanje = 15.0f;
    public float increment = 0.005f;
    public Meteor meteorPrefab;
     

	// Use this for initialization
	private void Start () {

        InvokeRepeating("Spawn",this.spawnRate, this.spawnRate);
	}


    private void Spawn()
    {
        for(int i = 0; i<this.spawnRate; i++)
        {

            Vector3 spawnSmijer = UnityEngine.Random.insideUnitCircle.normalized * this.spawnDaljina;
            Vector3 spawnTocka=this.transform.position+spawnSmijer;

            float varijanca = UnityEngine.Random.Range(-this.varijancaPutanje, this.varijancaPutanje);
            Quaternion rotacija = Quaternion.AngleAxis(varijanca, Vector3.forward);
            Meteor meteor = Instantiate(this.meteorPrefab, spawnTocka, rotacija) as Meteor;
            meteor.vel = UnityEngine.Random.Range(meteor.minVel, meteor.maxVel);
            meteor.SetTrajectory(rotacija * -spawnSmijer);
        }

        this.spawnRate = this.spawnRate + (this.spawnRate * increment);
    }

	// Update is called once per frame
	void Update () {
	
	}
}
