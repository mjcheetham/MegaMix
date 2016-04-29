
namespace CS_ClassLibrary.LinearAlgebra
{
    public class SimpleMatrix3InverseAlgorithm : IMatrix3InverseAlgorithm
    {
        public Matrix3 Inverse(Matrix3 matrix)
        {
            var det = matrix.Determinant();
            if (FloatingPointHelper.AlmostEqual(det, 0))
            {
                throw new NoInverseException();
            }

            var adj = matrix.Adjoint();

            return (1 / det) * adj;
        }
    }
}