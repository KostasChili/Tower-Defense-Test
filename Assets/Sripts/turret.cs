using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turret : MonoBehaviour
{
    [Header("Attributes")]
    public Transform Target;
    public float range = 10f;
    public float fireRate = 1f;
    private float fireCountDown = 0f;

    [Header("Unity setup")]
    public string enemyTag = "Enemy";
    [Range(1f,10f)]
    public float rotspeed = 2;

    public Transform baseRotation;
    public Transform gunRotation;

    public GameObject bullet;
    public Transform rightbarrelTip;
    public Transform leftbarrelTip;

   

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("updateTarget", 0f, 0.5f);
        //invokes a function every set ammount of time
    }


    void updateTarget() //not everyframe,sometimes a second
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;

        foreach (GameObject enemy in enemies)
        {
            float distanceToenemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distanceToenemy<shortestDistance)
            {
                shortestDistance = distanceToenemy;
                nearestEnemy = enemy;
            }
            
        }
        if (nearestEnemy != null && shortestDistance <= range)
        {
            Target = nearestEnemy.transform;
        }
        else
            Target = null;
    }


    
    void Update()
    {
        if (Target == null)
            return;

        
        Vector3 direction = Target.position - transform.position;
        Quaternion baseRot = Quaternion.LookRotation(direction);
        Vector3 horizontalRoation = Quaternion.Lerp(baseRotation.rotation, baseRot, Time.deltaTime * rotspeed).eulerAngles;
        baseRotation.rotation = Quaternion.Euler(0f, horizontalRoation.y, 0f);

        if (fireCountDown<=0f)
        {
            Shoot();
            fireCountDown = 1f / fireRate;
        }
        fireCountDown -= Time.deltaTime;
        


    }



    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }

    private bool rightbarrelShot=false;
    void Shoot()
    {
        if (!rightbarrelShot)
        {
            //reference to the bullet object
            GameObject bulletGO = (GameObject)Instantiate(bullet, rightbarrelTip.position, rightbarrelTip.rotation);
            //reference to the bullet script
            bullet led = bulletGO.GetComponent<bullet>();
            rightbarrelShot = !rightbarrelShot;

            if (led != null)//if that is actually a component on that object
            {
                led.Seek(Target);
                //pass the target to the bullet script
            }
        }
        else if(rightbarrelShot)
        {
            //reference to the bullet object
            GameObject bulletGO = (GameObject)Instantiate(bullet, leftbarrelTip.position, leftbarrelTip.rotation);
            //reference to the bullet script
            bullet led = bulletGO.GetComponent<bullet>();
            rightbarrelShot = !rightbarrelShot;

            if (led != null)//if that is actually a component on that object
            {
                led.Seek(Target);
                //pass the target to the bullet script
            }

        }

        
    }
}
