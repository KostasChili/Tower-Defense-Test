using UnityEngine;

public class NodeScrip : MonoBehaviour
{
    public Color hoverColor;
    public GameObject spawnPoint;

    buildManager buildManager;

    private GameObject builtTurret;
    private Color startColor;
    private Renderer Rend;
     void Start()
    {
        Rend = GetComponent<Renderer>(); //cache the renderer componet at the beggining   
        startColor = Rend.material.color;

        buildManager = buildManager.instance;
    }

     void OnMouseEnter()
    {
        if (buildManager.GetTurretToBuild() == null)
            return;
        Rend.material.color = hoverColor;   
    }
    private void OnMouseExit()
    {
        Rend.material.color = startColor;
    }

     void OnMouseDown()
    {
        if (buildManager.GetTurretToBuild() == null)
            return;

        if (builtTurret!=null)
        {
            Debug.Log("Sell the turre");
            return;
        }

        GameObject turretTOBuild = buildManager.instance.GetTurretToBuild();
        builtTurret = (GameObject)Instantiate(turretTOBuild, spawnPoint.transform.position,spawnPoint.transform.rotation);
        buildManager.instance.SetTurretToBuild(null);
      
    }


}
