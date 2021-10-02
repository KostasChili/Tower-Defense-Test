using UnityEngine;

public class shop : MonoBehaviour
{

    buildManager buildManager;

     void Start()
    {
        buildManager = buildManager.instance; 
    }
    public void buyStandardTurret()
    {
        Debug.Log("standart turret bought");
        buildManager.SetTurretToBuild(buildManager.standardTurretPrefab);
    }

    public void buyMissileTurret()
    {
        Debug.Log("missile turret bought");
        buildManager.SetTurretToBuild(buildManager.missileTurretPrefab);
    }


}
