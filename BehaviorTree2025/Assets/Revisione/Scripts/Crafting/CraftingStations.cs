using UnityEngine;

public class CraftingStations : MonoBehaviour
{
    public static CraftingStations Instance;
    
    private void Awake()
    {
        Instance = this;
    }

    public Transform CraftingBench;
    public Transform Wood;
    public Transform Metal;
    public Transform Cloth;
    public Transform Deposit;
}
