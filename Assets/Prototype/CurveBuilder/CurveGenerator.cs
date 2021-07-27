using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CurveBuilder
{
    public interface CurveGenerator 
    {
        Vector3[] GetCurve(Vector3[] controlPoints, float resolution = 0.02f);
    }
}