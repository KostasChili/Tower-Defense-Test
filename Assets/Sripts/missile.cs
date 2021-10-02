
using UnityEngine;

public class missile : MonoBehaviour
{
    [Range(1f, 10f)]
    public float missileSpeed = 2f;
    private Transform target;
    public GameObject impactEffect;

    public void Seek(Transform _target)
    {
        target = _target;
    }

     void Update()
    {
        if(target==null)
        {
            Destroy(this.gameObject);
            return;
        }
        //we calculate our direction to the target
        Vector3 directionToTarget = target.transform.position - transform.position;
        //we set our x/dt of distance for each frame
        float distanceInFrame = missileSpeed * Time.deltaTime;
        //we checked if we overshoot the target (meaning we hit)
        if(directionToTarget.magnitude<=distanceInFrame)
        {
            targetHit();
            return;
        }
        //if we have a way to go move
        transform.Translate(directionToTarget.normalized*distanceInFrame, Space.World);

    }

    void targetHit()
    {
        GameObject effectInstance = (GameObject)Instantiate(impactEffect, transform.position, transform.rotation);
        Destroy(gameObject);
        Destroy(target.gameObject);
    }


}
