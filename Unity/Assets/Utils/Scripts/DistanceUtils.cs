using UnityEngine;

public static class DistanceUtil
{
    public static float ClampedDistance(GameObject a, GameObject b, float range)
    {
        float trueDistance = Vector3.Distance(a.transform.position, b.transform.position);
        return Mathf.Min(100, (trueDistance / range) * 100);
    }

    public static GameObject FindClosest(GameObject startingPoint, GameObject[] targets)
    {
        GameObject closest = null;
        float closestDistance = Mathf.Infinity;
        foreach (GameObject target in targets) {
            float dist = Vector3.Distance(startingPoint.transform.position, target.transform.position);
            if (closest == null || closestDistance > dist) {
                closest = target;
                closestDistance = dist;
            }
        }
        return closest;
    }

    public static float FindClosestReturnClampedDistance(GameObject startingPoint, GameObject[] targets, float range)
    {
        GameObject closest = DistanceUtil.FindClosest(startingPoint, targets);
        return ClampedDistance(startingPoint, closest, range);
    }
}
