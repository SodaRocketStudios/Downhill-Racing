using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Curve
{
    public class Bezier : MonoBehaviour
    {
        [SerializeField]
        private Transform[] controlPoints = new Transform[4];

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.white;

            Vector3 previousPosition = controlPoints[0].position;

            Vector3[] curve = GetCurve(controlPoints[0].position, controlPoints[1].position, controlPoints[2].position, controlPoints[3].position);

            for(int i = 1; i < curve.Length; i++)
            {
                Gizmos.DrawLine(curve[i - 1], curve[i]);
            }
        }

        public Vector3[] GetCurve(Vector3 A, Vector3 B, Vector3 C, Vector3 D)
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

        private Vector3 GetPoint(Vector3 A, Vector3 B, Vector3 C, Vector3 D, float t)
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
