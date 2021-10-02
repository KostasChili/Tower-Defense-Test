
using UnityEngine;

public class MissileTurret : MonoBehaviour
{
    [Header("Attributes")]

    public Transform Target;
    [Range(1f,30f)]
    public float range = 10f;
    [Range(0.1f, 1f)]
    public float fireRate = 0.3f;
    private float fireCountDown = 0f;

    [Header("Unity setup")]
    public string enemyTag = "Enemy";
    [Range(1f, 10f)]
    public float rotspeed = 2;

    public Transform baseRotation;
    public Transform weapongRotation;

    public Transform barrel;
    public GameObject missile;


     void Start()
    {
        InvokeRepeating("updateTarget", 0f, 0.5f);
        Target = null;
    }


    void updateTarget()
    {
        GameObject[] enemyList = GameObject.FindGameObjectsWithTag(enemyTag);
        float shortestDistance = Mathf.Infinity;
        GameObject closestEnemy = null;

        foreach(GameObject enemy in enemyList)
        {
            
            float distancetoEnemy = Vector3.Distance(transform.position,enemy.transform.position);
            if (distancetoEnemy < shortestDistance)
            {
                shortestDistance = distancetoEnemy;
                closestEnemy = enemy;
            }
            if (closestEnemy != null && shortestDistance <= range)
            {
                Target = closestEnemy.transform;
            }
            else
                Target = null;
        }

    }

     void Update()
    {
        if (Target == null)
            return;

        Vector3 directiontoTarget = Target.position - transform.position;
        Quaternion baseRot = Quaternion.LookRotation(directiontoTarget);
        Vector3 horizontalRotation = Quaternion.Lerp(baseRotation.rotation, baseRot, Time.deltaTime * rotspeed).eulerAngles;
        baseRotation.rotation = Quaternion.Euler(0f, horizontalRotation.y, 0f);

       if(fireCountDown<=0)
        {
            shoot();
            fireCountDown = 1f / fireRate;
        }
        fireCountDown -= Time.deltaTime;
    }

     void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }

    void shoot()
    {
        GameObject missileGo = (GameObject)Instantiate(missile, barrel.position, barrel.rotation);
        missile rocket = missileGo.GetComponent<missile>();
        if(rocket!=null)
        {
            rocket.Seek(Target);
        }
       
           
    }
}
