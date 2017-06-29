using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class TestAntyBodyGameController : AntiBodyBaseGameController
{
    public override void SetStaticData(AntiBodyVO data)
    {
        base.SetStaticData(data);
        Debug.Log("Test OK");
    }

}
