using UnityEngine;

public class bullet : MonoBehaviour
{
    [Range(1f, 50f)]
    public float bullSpeed=10f;
    private Transform target;
    public GameObject impactEffect;


    //this function is referenced to the turret script passing the actual target (_target) to the target variable
    public void Seek(Transform _target)
    {
        target = _target;
        
    }

     void Update()
    {
       if (target==null)
        {
            Destroy(gameObject);
            return;//return beacuse destroy takes sometime 
        }
        Vector3 directiontoTarget = target.position - transform.position;
        float distanceThisFrame = bullSpeed * Time.deltaTime;

        if(directiontoTarget.magnitude<=distanceThisFrame) //if the current distance to target is <= to the distance we 
                                                           //we coverred this frame then we have hit the target
        {
            targetHit();
            return;
        }

        transform.Translate(directiontoTarget.normalized * distanceThisFrame, Space.World);
    }

    void targetHit()
    {
       GameObject effectInstance= (GameObject) Instantiate(impactEffect, transform.position, transform.rotation);
        Destroy(effectInstance, 2f);
        Destroy(gameObject);
        Destroy(target.gameObject);
        
    }

}
