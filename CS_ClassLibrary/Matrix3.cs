using System;
using System.Linq;

namespace CS_ClassLibrary
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

        public static Matrix3 Identity => new Matrix3(new[,] { { 1d, 0d, 0d }, { 0d, 1d, 0d }, { 0d, 0d, 1d } });

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

        public static bool operator ==(Matrix3 a, Matrix3 b)
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (!FloatingPointHelper.AlmostEqual(a[i, j], b[i, j]))
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        public static bool operator !=(Matrix3 a, Matrix3 b)
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (FloatingPointHelper.AlmostEqual(a[i, j], b[i, j]))
                    {
                        return true;
                    }
                }
            }

            return false;
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
