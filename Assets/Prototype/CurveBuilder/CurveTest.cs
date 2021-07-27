using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CurveBuilder
{
    public class CurveTest : MonoBehaviour
    {
        public Vector3[] controlPoints;
        private void OnDrawGizmos()
        {
            Gizmos.color = Color.white;

            for(int i = 0; i < controlPoints.Length; i++)
            {
                Gizmos.DrawCube(controlPoints[i], Vector3.one*1f);
            }

            Vector3[] curvePoints = Bezier.GetCurve(controlPoints);

            for(int i = 0; i < curvePoints.Length - 1; i++)
            {
                Gizmos.DrawLine(curvePoints[i], curvePoints[i+1]);
            }
        }
    }
}
