using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// MAKE A FUCKING PROPER INPUT HANDLER INSTEAD OF THIS SHIT

public class MousetoWorld : MonoBehaviour
{
    public GameObject mouseClickIcon;
    public SteeringBehaviour playerSteering;
    public Summoner playerSummoning;
    public float distanceToSurface = 10;
    public float iconLifeTime = 5;

    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            GetMouseWorldSpace();
        }
    }

    public Vector3 GetMouseWorldSpace()
    {
        Ray mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if(Physics.Raycast(mouseRay, out hit, distanceToSurface))
        {
            Vector3 trueHit = new Vector3(hit.point.x, hit.point.y + (mouseClickIcon.transform.lossyScale.y), hit.point.z);

            GameObject tempClickIcon = Instantiate(mouseClickIcon, trueHit, Quaternion.identity);
            GameObject.Destroy(tempClickIcon, iconLifeTime);
            return trueHit;
        }

        Debug.Log("Did Not Hit Surface");
        return new Vector3();
    }
}
