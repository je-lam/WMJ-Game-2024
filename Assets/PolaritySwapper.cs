using UnityEngine;

public class PolaritySwapper : MonoBehaviour
{
    // SOUTH BY DEFAULT.

    private void Update()
    {
        SwapPolarities();
        print(gameObject.layer);
    }
    const string NORTH_MAGNET = "North Magnet";
    const string SOUTH_MAGNET = "South Magnet";
    void SwapPolarities()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            if (gameObject.layer == 6)
            {
                gameObject.layer = 7;
            }
            else
            {
                gameObject.layer = 6;
            }
        }
    }

}
