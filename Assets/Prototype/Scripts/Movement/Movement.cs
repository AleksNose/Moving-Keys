using System;
using System.Collections.Generic;

public class Movement
{
    public Dictionary<TypeMove, bool> TypeCanMove;

    private void Awake()
    {
        TypeCanMove = new Dictionary<TypeMove, bool>();

        foreach (TypeMove type in Enum.GetValues(typeof(TypeMove)))
            TypeCanMove.Add(type, true);
    }

    private void OnMove(TypeMove type)
    {

    }
}
