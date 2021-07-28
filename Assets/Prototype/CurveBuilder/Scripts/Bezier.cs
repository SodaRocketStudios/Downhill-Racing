using UnityEngine;

namespace CurveBuilder
{
    public class Bezier : CurveGenerator
    {
        // Returns an array of points that define the vertices of a bezier curve.
        public Vector3[] GetCurve(Vector3[] controlPoints, int resolution = 10)
        {
            // If there aren't at least 2 points.
            if(controlPoints.Length < 2)
            {
                Debug.LogWarning($"A curve needs at least two points, you provided {controlPoints.Length}.");
                return new Vector3[]{Vector3.zero};
            }

            Vector3[] curvePoints = new Vector3[resolution+1];

            for(int i = 0; i <= resolution; i++)
            {
                float t = i*1.0f/resolution;
                curvePoints[i] = GetPoint(controlPoints, t);
            }

            return curvePoints;
        }

        // Get the vertex at point t along the curve.
        private Vector3 GetPoint(Vector3[] controlPoints, float t)
        {
            int numberOfPoints = controlPoints.Length;
            int dimesion = numberOfPoints - 1;

            Vector3[,] interpolatedPoints = new Vector3[numberOfPoints, numberOfPoints];

            for(int i = 0; i < numberOfPoints; i++)
            {
                interpolatedPoints[0, i] = controlPoints[i];
            }

            for(int i = 0; i < dimesion; i++)
            {
                for(int j = 0; j < dimesion - i; j++)
                {
                    interpolatedPoints[i+1, j] = Vector3.Lerp(interpolatedPoints[i, j], interpolatedPoints[i, j+1], t);
                }
            }
            return interpolatedPoints[dimesion, 0];
        }
    }    
}