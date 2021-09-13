using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour {


    private Image HealthBarr;
    private float maxHealth;
    public float currentHealth;
    KretanjeIgrac igrac;

    // Use this for initialization
    void Start () {

        HealthBarr = GetComponent<Image>();
        igrac = FindObjectOfType<KretanjeIgrac>();
        maxHealth = igrac.snaga;
    }
	
	// Update is called once per frame
	void Update () {

        currentHealth = igrac.snaga;
        HealthBarr.fillAmount = currentHealth / maxHealth;
    }
}
