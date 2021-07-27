using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CurveBuilder
{
    public class CurveTest : MonoBehaviour
    {
        public Vector3[] controlPoints;
        Curve curve;

        private void OnDrawGizmos()
        {
            if(curve == null)
            {
                curve = new Curve(Bezier.GetCurve(controlPoints));
            }
            else
            {
                curve.SetVertices(Bezier.GetCurve(controlPoints));
            }

            Gizmos.color = Color.white;

            for(int i = 0; i < controlPoints.Length; i++)
            {
                Gizmos.DrawSphere(controlPoints[i], .1f);
            }
        }
    }
}
