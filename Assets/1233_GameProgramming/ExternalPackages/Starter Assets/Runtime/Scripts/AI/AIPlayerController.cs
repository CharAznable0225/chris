using UnityEngine;

public class AIPlayerController : MonoBehaviour
{
    void Start()
    {
        // This line had no effect. Add logic here if needed.
        var _ = PlayerLocatorSingleton.Instance;
    }

    void Update()
    {
        // You can add AI input logic here if needed.
    }
}
