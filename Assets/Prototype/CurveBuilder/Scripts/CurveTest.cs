using UnityEngine;

namespace CurveBuilder
{
    public class CurveTest : MonoBehaviour
    {
        public Vector3[] controlPoints;
        CurveData curve;

        private void OnDrawGizmos()
        {
            curve = new CurveData(controlPoints, CurveType.bezier);

            Gizmos.color = Color.white;

            for(int i = 0; i < controlPoints.Length; i++)
            {
                Gizmos.DrawSphere(controlPoints[i], .1f);
            }
        }
    }
}
