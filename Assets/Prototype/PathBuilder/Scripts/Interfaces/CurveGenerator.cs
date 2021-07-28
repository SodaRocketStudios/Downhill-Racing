using UnityEngine;

namespace PathBuilder
{
    public interface CurveGenerator 
    {
        Vector3[] GetCurve(Vector3[] controlPoints, int resolution = 10);
    }
}