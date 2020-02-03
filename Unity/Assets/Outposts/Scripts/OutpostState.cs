using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/OutpostState", order = 1)]
public class OutpostState : ScriptableObject
{
    public string state_name;
    public Color light;
    public Color dark;
    public bool isInteractive;
    public bool isVegetationRepaied;
}