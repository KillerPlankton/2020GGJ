using UnityEngine;
using System.Collections;

public class PlayerSoundManager : MonoBehaviour
{
    public AK.Wwise.RTPC monstreDistance;
    public AK.Wwise.RTPC OutpostDistance;

    public GameObject wwiseObj;
    [SerializeField]
    private float monsterRange, outpostRange;

    [SerializeField]
    private GameObject monster;

    [SerializeField]
    private GameObject[] outposts;

    private float closestOutpost, monsterDistance;

    void Update()
    {
        this.monsterDistance = DistanceUtil.ClampedDistance(this.gameObject, monster, monsterRange);
        // USE monsterDistance TO SETUP WWISE MONSTER SOUND INTENSITY HERE.
        monstreDistance.SetValue(wwiseObj, this.monsterDistance);
        this.closestOutpost = DistanceUtil.FindClosestReturnClampedDistance(this.gameObject, outposts, outpostRange);
        // USE closestOutpost TO SETUP WWISE OUTPOST SOUND INTENSITY HERE.
        OutpostDistance.SetValue(wwiseObj, this.closestOutpost);
        Debug.Log(closestOutpost);
    }
}
