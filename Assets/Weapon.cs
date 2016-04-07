using UnityEngine;
using System.Collections;

public class Weapon : MonoBehaviour {

    public float fireRate = 0;
    public float dmg = 5;
    public float range = 100;
    public LayerMask notToHit;

    float timeToFire = 0;
    Transform firePoint;

	// Use this for initialization
	void Awake () 
    {
        firePoint = transform.FindChild("FirePoint");
        if (firePoint == null)
        {
            Debug.LogError("missing firepoint");
        }
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (fireRate == 0)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                Shoot();
            }
        }
        else if (Input.GetButton("Fire1") && Time.time > timeToFire)
	    {
            timeToFire = Time.time + 1 / fireRate;
            Shoot();
    	}
	}
    void Shoot()
    {
        Vector2 mousePosition = new Vector2
            (Camera.main.ScreenToWorldPoint(Input.mousePosition).x,
            Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
        Vector2 firePointPosition = new Vector2(firePoint.position.x, firePoint.position.y);
        RaycastHit2D hit = Physics2D.Raycast(firePointPosition, mousePosition - firePointPosition, range, notToHit);
        Debug.DrawLine(firePointPosition, mousePosition);
    }
}
