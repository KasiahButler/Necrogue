using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// MAKE A FUCKING PROPER INPUT HANDLER INSTEAD OF THIS SHIT

public class MousetoWorld : MonoBehaviour
{
    public GameObject mouseClickIcon;
    public SteeringBehaviour playerSteering;
    public Summoner playerSummoning;
    public float iconLifeTime = 5;

    public void Update()
    {
        if (Input.GetMouseButtonDown(0)) ;
        {
            if (Input.GetKey(KeyCode.LeftControl))
            {
                if(playerSummoning.summonDelta >= playerSummoning.summoningTime)
                {
                    playerSummoning.SummonObject(GetMouseWorldSpace());
                    playerSummoning.summonDelta = 0;
                }
            }
            else playerSteering.SetTargetPosition(GetMouseWorldSpace());
        }
    }

    public Vector3 GetMouseWorldSpace()
    {
        Ray mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if(Physics.Raycast(mouseRay, out hit, Mathf.Infinity))
        {
            Vector3 trueHit = new Vector3(hit.point.x, hit.point.y + (mouseClickIcon.transform.lossyScale.y), hit.point.z);

            GameObject tempClickIcon = Instantiate(mouseClickIcon, trueHit, Quaternion.identity);
            GameObject.Destroy(tempClickIcon, iconLifeTime);
            return trueHit;
        }

        return new Vector3();
    }
}
