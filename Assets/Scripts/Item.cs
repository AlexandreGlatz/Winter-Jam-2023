using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "Create Item", order = 1)]
public class Item : ScriptableObject
{

    [Header("Infos")]
    public int Id;
    public string Name;
    public Sprite Image;
    public string Description;
    public string Zone;

    [Header("Parameters")]
    public bool InPossess = false;
    
}
