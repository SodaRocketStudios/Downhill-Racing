using UnityEngine;

namespace CurveBuilder
{
    public static class Bezier
    {
        public static Vector3[] GetCurve(Vector3[] controlPoints, float resolution = 0.02f)
        {
            // If there aren't at least 2 points.
            if(controlPoints.Length < 2)
            {
                Debug.LogWarning($"A curve needs at least two points, you provided {controlPoints.Length}.");
                return new Vector3[]{Vector3.zero};
            }

            Vector3[] curvePoints = new Vector3[Mathf.RoundToInt(1f/resolution) + 1];

            int i = 0;
            for(float t = 0; t <= 1; t += resolution, i++)
            {
                curvePoints[i] = GetPoint(controlPoints, t);
            }

            return curvePoints;
        }

        private static Vector3 GetPoint(Vector3[] controlPoints, float t)
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