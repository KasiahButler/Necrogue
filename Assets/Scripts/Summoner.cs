using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Summoner : MonoBehaviour
{
    public GameObject summonableObject;
    public float summoningTime;
    public float summonDelta;

    private List<GameObject> summons = new List<GameObject>();

    public void SummonObject(Vector3 summonPosition)
    {
        SteeringBehaviour holderSummon = Instantiate(summonableObject, summonPosition, Quaternion.identity).GetComponent<SteeringBehaviour>();
        holderSummon.followTransform = this.transform;
        holderSummon.isAutomated = true;
    }
}
