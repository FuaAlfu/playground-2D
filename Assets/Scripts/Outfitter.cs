using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.U2D.Animation;

/// <summary>
/// 2021.10.31
/// </summary>


public class Outfitter : MonoBehaviour
{
    private List<SpriteResolver> _resolvers;
    private UnitType _type;
    private enum UnitType
    {
        Red,
        Green
    }

    //private void Awake() => _resolvers = GetComponentsInChildren<SpriteResolver>().ToList;

    // Update is called once per frame
    void Update()
    {
       if(Input.GetKeyDown(KeyCode.A))
        {
            _type = _type == UnitType.Red ? UnitType.Green : UnitType.Red;
            ChangeOutfit();
        }
    }

    private void ChangeOutfit()
    {
        foreach(var resolver in _resolvers)
        {
            resolver.SetCategoryAndLabel(resolver.GetCategory(), _type.ToString());
        }
    }
}
