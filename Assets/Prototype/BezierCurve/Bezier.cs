using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Curve
{
    public static class Bezier
    {
        public static Vector3[] GetCurve(Vector3 A, Vector3 B, Vector3 C, Vector3 D)
        {
            float resolution = 0.02f;

            Vector3[] curvePoints = new Vector3[Mathf.RoundToInt(1f/resolution) + 1];

            int i = 0;
            for(float t = 0; t <= 1; t += resolution, i++)
            {
                curvePoints[i] = GetPoint(A, B, C, D, t);
            }

            return curvePoints;
        }

        private static Vector3 GetPoint(Vector3 A, Vector3 B, Vector3 C, Vector3 D, float t)
        {
            // Linear interpolation
            Vector3 l0 = Vector3.Lerp(A, B, t);
            Vector3 l1 = Vector3.Lerp(B, C, t);
            Vector3 l2 = Vector3.Lerp(C, D, t);

            // Quadratic interpolation
            Vector3 Q0 = Vector3.Lerp(l0, l1, t);
            Vector3 Q1 = Vector3.Lerp(l1, l2, t);

            // Cubic interpolation
            Vector3 C0 = Vector3.Lerp(Q0, Q1, t);

            return C0;
        }
    }    
}