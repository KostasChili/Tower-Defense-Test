
using UnityEngine;

public class buildManager : MonoBehaviour
{
   

    //outer reference singleton patern
    //make sure there is only one build manager instance in this scene
    public static buildManager instance; //store a reference to iteself


      void Awake()
    {
        if (instance != null)
        {
            Debug.Log("more than one BuildManager in the scene");
            return;
        }
        //this build manager is put in the instance variable and becasue it is static it can be accessed by all sripts
        instance = this;   
    }

    public GameObject standardTurretPrefab;
    public GameObject missileTurretPrefab;
    public GameObject bonkTurretPrefab;
    

    private GameObject turretTobuild;
    public GameObject GetTurretToBuild()
    {
        return turretTobuild;
    }
    public void SetTurretToBuild(GameObject turret)
    {
        turretTobuild = turret;
    }
}
