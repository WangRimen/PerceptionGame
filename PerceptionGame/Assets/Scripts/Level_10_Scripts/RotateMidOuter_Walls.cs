﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateMidOuter_Walls : RotateWalls
{

    // **********************************************************************************************************************

    // Use this for initialization
    public override void Start()
    {
        base.Start();

        base.Direction = -1.0f;
    }//END: Start()

    // **********************************************************************************************************************

    // Update is called once per frame
    void Update()
    {

    }//END: Update()

    // **********************************************************************************************************************

}//END: RotateMidOuter_Walls
