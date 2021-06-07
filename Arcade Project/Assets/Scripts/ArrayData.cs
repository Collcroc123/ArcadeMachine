using UnityEngine;

[CreateAssetMenu]
public class ArrayData : ScriptableObject
{
    public string[] songAddresses;
    
    public void Clear()
    {
        for (int i = 0; i < songAddresses.Length; i++)
        {
            songAddresses[i] = null;
        }
    }
}
