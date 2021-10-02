using UnityEngine;

public class CameraController : MonoBehaviour
{
    [Range(1f,30f)]
    public float panSpeed=30f;//paning movment in x/z axis (flat plane)
    [Range(1f, 10f)]
    public float panBorderThickness = 5f;
    [Range(1f, 30f)]
    public float scrollSpeed= 10f;
    public float minY = 10f;
    public float maxY = 30f;


    private bool canMove = true;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            canMove = !canMove;
        }
        if(!canMove)
        {
            return;
        }
       if(Input.GetKey("w") || Input.mousePosition.y>=Screen.height-panBorderThickness)
        {
            transform.Translate(Vector3.forward*panSpeed*Time.deltaTime,Space.World); 
            //translate movemnt in a direction without physics
            //Space.world makes the coordinates use the global system and not the local one
        }
        if (Input.GetKey("s") || Input.mousePosition.y <= panBorderThickness)
        {
            transform.Translate(Vector3.back * panSpeed * Time.deltaTime, Space.World);   
        }
        if (Input.GetKey("d") || Input.mousePosition.x >=Screen.width- panBorderThickness)
        {
            transform.Translate(Vector3.right * panSpeed * Time.deltaTime, Space.World);
        }
        if (Input.GetKey("a") || Input.mousePosition.x <=panBorderThickness)
        {
            transform.Translate(Vector3.left * panSpeed * Time.deltaTime, Space.World);
        }

        float scroll = Input.GetAxis("Mouse ScrollWheel");
        Vector3 pos = transform.position;
        pos.y -= scroll* 1000 * scrollSpeed*Time.deltaTime;
        pos.y = Mathf.Clamp(pos.y, minY, maxY);

        transform.position = pos;
        

       
    }

}
