using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyListBox : BaseListBank
{
    private int[] _contents = {
        1, 2, 3, 4, 5
    };
    public override string GetListContent(int index)
    {
        return _contents[index].ToString();
    }
    public override int GetListLength()
    {
        return _contents.Length;
    }
}