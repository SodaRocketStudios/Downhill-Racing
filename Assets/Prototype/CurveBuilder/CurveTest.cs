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
            curve = new Curve(controlPoints);

            Gizmos.color = Color.white;

            for(int i = 0; i < controlPoints.Length; i++)
            {
                Gizmos.DrawSphere(controlPoints[i], .1f);
            }
        }
    }
}
