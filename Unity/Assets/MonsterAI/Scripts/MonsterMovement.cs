using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class MonsterMovement : MonoBehaviour
{
    [SerializeField]
    private float destructionScale;
    [SerializeField]
    private GameObject trailPrefab;

    private NavMeshAgent agent;
    private GameObject destroyedAreasHolder;

    private List<Vector3> outposts = new List<Vector3>();
    private Vector3 ldPosition; // Latest Destruction Position

    // ============================================================================================
    // LIFECYCLE ==================================================================================
    // ============================================================================================

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        GameObject[] outpostsGO = GameObject.FindGameObjectsWithTag("Outpost");
        foreach (GameObject outpost in outpostsGO)
        {
            this.outposts.Add(outpost.transform.position);
        }
        destroyAreaIfNeeded();
    }

    void Update()
    {
        findNewPatrolTarget();
        destroyAreaIfNeeded();
    }

    // ============================================================================================
    // MONSTER BEHAVIOURS =========================================================================
    // ============================================================================================

    /// <summary>
    /// If the monster has no current target, sends it back to patrolling.
    /// </summary>
    private void findNewPatrolTarget()
    {
        if (!this.agent.hasPath)
        {
            int targetOutpostIndex = Random.Range(0, this.outposts.Count - 1);
            this.agent.SetDestination(this.outposts[targetOutpostIndex]);
        }

    }

    /// <summary>
    /// Destroys the surrounding area by spawning destruction spheres triggering
    /// nature changes (living/dead)
    /// </summary>
    private void destroyAreaIfNeeded()
    {

        void destroyArea()
        {
            if (destroyedAreasHolder == null) {
                destroyedAreasHolder = new GameObject();
                destroyedAreasHolder.name = "DestroyedAreas_" + this.gameObject.name;
            }

            GameObject trailGO = Instantiate(trailPrefab, transform.position, Quaternion.identity);

            this.ldPosition = this.transform.position;
            trailGO.transform.position = this.ldPosition;
            trailGO.transform.localScale = new Vector3(
                this.destructionScale,
                this.destructionScale,
                this.destructionScale);
            trailGO.transform.parent = destroyedAreasHolder.transform;
        }

        Debug.Log("Destruction Distance:" + Vector3.Distance(this.transform.position, ldPosition));

        if (this.ldPosition == null)
        {
            destroyArea();
        }
        else if (Vector3.Distance(this.transform.position, ldPosition) > this.destructionScale)
        {
            destroyArea();
        }
    }
}
