using CS_ClassLibrary;
using CS_ClassLibrary.LinearAlgebra;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CS_UnitTest
{
    [TestClass]
    public class Matrix3Tests
    {
        [TestMethod]
        public void OpAddition_TwoMatrices_ReturnsElementWiseAdditionMatrix()
        {
            // Setup
            var a = new Matrix3(new[,] { { 1d, 2d, 3d }, { 4d, 5d, 6d }, { 7d, 8d, 9d } });
            var b = new Matrix3(new[,] { { 9d, 8d, 7d }, { 6d, 5d, 4d }, { 3d, 2d, 1d } });

            var expected = new Matrix3(new[,] { { 10d, 10d, 10d }, { 10d, 10d, 10d }, { 10d, 10d, 10d } });

            // Act
            var actual = a + b;

            // Verify
            Assert.AreEqual(expected.M11, actual.M11);
            Assert.AreEqual(expected.M12, actual.M12);
            Assert.AreEqual(expected.M13, actual.M13);
            Assert.AreEqual(expected.M21, actual.M21);
            Assert.AreEqual(expected.M22, actual.M22);
            Assert.AreEqual(expected.M23, actual.M23);
            Assert.AreEqual(expected.M31, actual.M31);
            Assert.AreEqual(expected.M32, actual.M32);
            Assert.AreEqual(expected.M33, actual.M33);
        }

        [TestMethod]
        public void OpSubtract_TwoMatrices_ReturnsElementWiseSubtractionMatrix()
        {
            // Setup
            var a = new Matrix3(new[,] { { 1d, 2d, 3d }, { 4d, 5d, 6d }, { 7d, 8d, 9d } });
            var b = new Matrix3(new[,] { { 9d, 8d, 7d }, { 6d, 5d, 4d }, { 3d, 2d, 1d } });

            var expected = new Matrix3(new[,] { { -8d, -6d, -4d }, { -2d, 0d, 2d }, { 4d, 6d, 8d } });

            // Act
            var actual = a - b;

            // Verify
            Assert.AreEqual(expected.M11, actual.M11);
            Assert.AreEqual(expected.M12, actual.M12);
            Assert.AreEqual(expected.M13, actual.M13);
            Assert.AreEqual(expected.M21, actual.M21);
            Assert.AreEqual(expected.M22, actual.M22);
            Assert.AreEqual(expected.M23, actual.M23);
            Assert.AreEqual(expected.M31, actual.M31);
            Assert.AreEqual(expected.M32, actual.M32);
            Assert.AreEqual(expected.M33, actual.M33);
        }

        [TestMethod]
        public void OpMultiply_ScalarAndMatrix_ReturnsElementWiseScalarMultiplcationMatrix()
        {
            // Setup
            var scalar = -3.5;
            var matrix = new Matrix3(new[,] { { 1d, 2d, 3d }, { 4d, -5d, 0d }, { -0d, 80d, -0.05d } });

            var expected = new Matrix3(new[,] { { -3.5d, -7d, -10.5d }, { -14d, 17.5d, 0d }, { 0d, -280d, 0.175d } });

            // Act
            var actual = scalar * matrix;

            // Verify
            AssertAlmostEqual(expected.M11, actual.M11);
            AssertAlmostEqual(expected.M12, actual.M12);
            AssertAlmostEqual(expected.M13, actual.M13);
            AssertAlmostEqual(expected.M21, actual.M21);
            AssertAlmostEqual(expected.M22, actual.M22);
            AssertAlmostEqual(expected.M23, actual.M23);
            AssertAlmostEqual(expected.M31, actual.M31);
            AssertAlmostEqual(expected.M32, actual.M32);
            AssertAlmostEqual(expected.M33, actual.M33);
        }

        private void AssertAlmostEqual(double expected, double actual)
        {
            Assert.IsTrue(FloatingPointHelper.AlmostEqual(expected, actual), $"Expected: {expected} Actual: {actual}");
        }
    }
}
