﻿using System;
using System.Linq;

namespace CS_ClassLibrary.LinearAlgebra
{
    public class Matrix3 : IEquatable<Matrix3>
    {
        private readonly double[,] elements;

        public double this[int i, int j]
        {
            get
            {
                VerifyIndices(i, j);
                return elements[i, j];
            }
            set
            {
                VerifyIndices(i, j);
                elements[i, j] = value;
            }
        }

        #region Specialised element access

        public double M11
        {
            get { return elements[0, 0]; }
            set { elements[0, 0] = value; }
        }
        public double M12
        {
            get { return elements[0, 1]; }
            set { elements[0, 1] = value; }
        }
        public double M13
        {
            get { return elements[0, 2]; }
            set { elements[0, 2] = value; }
        }
        public double M21
        {
            get { return elements[1, 0]; }
            set { elements[1, 0] = value; }
        }
        public double M22
        {
            get { return elements[1, 1]; }
            set { elements[1, 1] = value; }
        }
        public double M23
        {
            get { return elements[1, 2]; }
            set { elements[1, 2] = value; }
        }
        public double M31
        {
            get { return elements[2, 0]; }
            set { elements[2, 0] = value; }
        }
        public double M32
        {
            get { return elements[2, 1]; }
            set { elements[2, 1] = value; }
        }
        public double M33
        {
            get { return elements[2, 2]; }
            set { elements[2, 2] = value; }
        }

        #endregion

        #region Constructors

        public Matrix3()
            : this(new double[3,3])
        {
        }

        public Matrix3(double[,] elements)
        {
            if (elements == null)
            {
                throw new ArgumentNullException(nameof(elements));
            }

            if (elements.GetLength(0) != 3 && elements.GetLength(1) != 3)
            {
                throw new ArgumentException();
            }

            this.elements = elements;
        }

        public static Matrix3 Identity => new Matrix3 { M11 = 1d, M22 = 1d, M33 = 1d };

        #endregion

        #region Operators

        public static Matrix3 operator +(Matrix3 a, Matrix3 b)
        {
            return new Matrix3(new double[3, 3])
            {
                M11 = a.M11 + b.M11,
                M12 = a.M12 + b.M12,
                M13 = a.M13 + b.M13,
                M21 = a.M21 + b.M21,
                M22 = a.M22 + b.M22,
                M23 = a.M23 + b.M23,
                M31 = a.M31 + b.M31,
                M32 = a.M32 + b.M32,
                M33 = a.M33 + b.M33
            };
        }

        public static Matrix3 operator -(Matrix3 a, Matrix3 b)
        {
            return new Matrix3(new double[3, 3])
            {
                M11 = a.M11 - b.M11,
                M12 = a.M12 - b.M12,
                M13 = a.M13 - b.M13,
                M21 = a.M21 - b.M21,
                M22 = a.M22 - b.M22,
                M23 = a.M23 - b.M23,
                M31 = a.M31 - b.M31,
                M32 = a.M32 - b.M32,
                M33 = a.M33 - b.M33
            };
        }

        public static Matrix3 operator -(Matrix3 m)
        {
            return new Matrix3(new double[3, 3])
            {
                M11 = -m.M11,
                M12 = -m.M12,
                M13 = -m.M13,
                M21 = -m.M21,
                M22 = -m.M22,
                M23 = -m.M23,
                M31 = -m.M31,
                M32 = -m.M32,
                M33 = -m.M33
            };
        }

        public static Matrix3 operator *(double scalar, Matrix3 matrix)
        {
            return new Matrix3
            {
                M11 = scalar * matrix.M11,
                M12 = scalar * matrix.M12,
                M13 = scalar * matrix.M13,
                M21 = scalar * matrix.M21,
                M22 = scalar * matrix.M22,
                M23 = scalar * matrix.M23,
                M31 = scalar * matrix.M31,
                M32 = scalar * matrix.M32,
                M33 = scalar * matrix.M33,
            };
        }

        public static bool operator ==(Matrix3 a, Matrix3 b)
        {
            return FloatingPointHelper.AlmostEqual(a[0, 0], b[0, 0])
                && FloatingPointHelper.AlmostEqual(a[0, 1], b[0, 1])
                && FloatingPointHelper.AlmostEqual(a[0, 2], b[0, 2])
                && FloatingPointHelper.AlmostEqual(a[1, 0], b[1, 0])
                && FloatingPointHelper.AlmostEqual(a[1, 1], b[1, 1])
                && FloatingPointHelper.AlmostEqual(a[1, 2], b[1, 2])
                && FloatingPointHelper.AlmostEqual(a[2, 0], b[2, 0])
                && FloatingPointHelper.AlmostEqual(a[2, 1], b[2, 1])
                && FloatingPointHelper.AlmostEqual(a[2, 2], b[2, 2]);
        }

        public static bool operator !=(Matrix3 a, Matrix3 b)
        {
            return !(a == b);
        }

        #endregion

        #region Multiplication

        public static Matrix3 ElementMultiply(Matrix3 a, Matrix3 b)
        {
            return new Matrix3
            {
                M11 = a.M11 * b.M11,
                M12 = a.M12 * b.M12,
                M13 = a.M13 * b.M13,
                M21 = a.M21 * b.M21,
                M22 = a.M22 * b.M22,
                M23 = a.M23 * b.M23,
                M31 = a.M31 * b.M31,
                M32 = a.M32 * b.M32,
                M33 = a.M33 * b.M33
            };
        }

        public Matrix3 ElementMultiply(Matrix3 other)
        {
            return ElementMultiply(this, other);
        }

        #endregion

        #region Determinant

        public double Determinant()
        {
            var a = this.M11;
            var b = this.M12;
            var c = this.M12;
            var d = this.M21;
            var e = this.M22;
            var f = this.M23;
            var g = this.M31;
            var h = this.M32;
            var i = this.M33;

            return (a * e * i)
                 + (b * f * g)
                 + (c * d * h)
                 - (c * e * g)
                 - (b * d * i)
                 - (a * f * h);
        }

        #endregion

        #region Inversion

        public Matrix3 Inverse() => this.Inverse(new SimpleMatrix3InverseAlgorithm());

        public Matrix3 Inverse(IMatrix3InverseAlgorithm inverter)
        {
            return inverter.Inverse(this);
        }

        #endregion

        #region Transposition

        public static Matrix3 Transpose(Matrix3 matrix)
        {
            return new Matrix3
            {
                M11 = matrix.M11,
                M12 = matrix.M21,
                M13 = matrix.M31,
                M21 = matrix.M12,
                M22 = matrix.M22,
                M23 = matrix.M32,
                M31 = matrix.M13,
                M32 = matrix.M23,
                M33 = matrix.M33
            };
        }

        public Matrix3 Transpose()
        {
            return Transpose(this);
        }

        #endregion

        #region Adjoint/Cofactor

        internal Matrix3 Adjoint()
        {
            return this.Cofactor().Transpose();
        }

        internal Matrix3 Cofactor()
        {
            var a = this.M11; // a b c
            var b = this.M12; // d e f
            var c = this.M12; // g h i
            var d = this.M21;
            var e = this.M22;
            var f = this.M23;
            var g = this.M31;
            var h = this.M32;
            var i = this.M33;

            // minors
            var m11 = e * i - f * h;
            var m12 = d * i - f * g;
            var m13 = d * h - e * g;
            var m21 = b * i - c * h;
            var m22 = a * i - c * g;
            var m23 = a * h - b * g;
            var m31 = b * f - c * e;
            var m32 = a * f - c * d;
            var m33 = a * e - b * d;

            return new Matrix3
            {
                M11 = m11,
                M12 = m12,
                M13 = m13,
                M21 = m21,
                M22 = m22,
                M23 = m23,
                M31 = m31,
                M32 = m32,
                M33 = m33
            };
        }

        #endregion

        #region Equality overrides

        public override bool Equals(object obj)
        {
            return Equals(obj as Matrix3);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (int)Enumerable.Range(0, elements.GetLength(1)).Sum(i => elements[1, i] * 1000);
            }
        }

        public bool Equals(Matrix3 other)
        {
            if (other == null)
            {
                return false;
            }

            return this == other;
        }

        #endregion

        private static void VerifyIndices(int i, int j)
        {
            if (i < 0 || i > 3 || j < 0 || j > 3)
            {
                throw new IndexOutOfRangeException();
            }
        }
    }
}