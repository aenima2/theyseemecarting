using UnityEngine;
using System.Collections;

public class CharacterSelectOld : MonoBehaviour
{

    [HideInInspector]
    public int CharacterIndex;
    [HideInInspector]
    public GameObject CharacterSelected;
    public GameObject[] CharactersAvailable;

    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

}
