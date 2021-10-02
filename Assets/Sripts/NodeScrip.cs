using UnityEngine;

public class NodeScrip : MonoBehaviour
{
    public Color hoverColor;
    public GameObject spawnPoint;

    private GameObject builtTurret;
    private Color startColor;
    private Renderer Rend;
     void Start()
    {
        Rend = GetComponent<Renderer>(); //cache the renderer componet at the beggining   
        startColor = Rend.material.color;
    }

     void OnMouseEnter()
    {
        Rend.material.color = hoverColor;   
    }
    private void OnMouseExit()
    {
        Rend.material.color = startColor;
    }

     void OnMouseDown()
    {
       if(builtTurret!=null)
        {
            Debug.Log("Sell the turre");
            return;
        }

        //GameObject turretTOBuild = buildManager.instance.GetTurretToBuild();
        //builtTurret = (GameObject)Instantiate(turretTOBuild, spawnPoint.transform.position,spawnPoint.transform.rotation);
      
    }


}
