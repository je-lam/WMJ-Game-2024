using UnityEngine;

public class PenguinBalancer : MonoBehaviour
{
    CharaMovement charaScript;
    void Start()
    {
        charaScript = GetComponentInParent<CharaMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        print(charaScript.activeCharacter);
        HandleBalancing();
    }

    void HandleBalancing()
    {
        if (charaScript.activeCharacter.Equals("bear"))
        {
            transform.localPosition = new Vector3(0, 0, 0);
        }
    }
}
