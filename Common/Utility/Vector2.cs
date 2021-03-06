using System;
using System.ComponentModel;


namespace Common.Utility
{
    public class Vector2 : IComparable, IComparable<Vector2>
    {
        private readonly int x;
        private readonly int y;
        
        public Vector2(int x, int y )
        {
            this.x = x;
            this.y = y;
        }
        public Vector2(int[] xy)
        {
            if (xy.Length == 3)
            {
                this.x = xy[0];
                this.y = xy[1];
                
            }
            else
            {
                throw new ArgumentException(THREE_COMPONENTS);
            }
        }
        public Vector2(Vector2 v1)
        {
            this.x = v1.X;
            this.y = v1.Y;
            
        }
        //#############################################################################################################################
        public int X
        {
            get
            {
                return this.x;
            }
        }
        //#############################################################################################################################
        public int Y
        {
            get
            {
                return this.y;
            }
        }
      

        //#############################################################################################################################
        public int[] Array
        {
            get
            {
                return new[] { this.x, this.y };
            }
        }
        //#############################################################################################################################
        public int this[int index]
        {
            get
            {
                switch (index)
                {
                    case 0:
                        return this.X;
                    case 1:
                        return this.Y;
                   
                    default:
                        throw new ArgumentException(THREE_COMPONENTS, "index");
                }
            }
        }
        //#############################################################################################################################
        public static Vector2 operator +(Vector2 v1, Vector2 v2)
        {
            return new Vector2(
                v1.X + v2.X,
                v1.Y + v2.Y);
               
        }
        //#############################################################################################################################
        public static Vector2 operator -(Vector2 v1, Vector2 v2)
        {
            return new Vector2(
                v1.X - v2.X,
                v1.Y - v2.Y);
             
        }
        //#############################################################################################################################
        public static Vector2 operator *(Vector2 v1, int s2)
        {
            return
                new Vector2(
                        v1.X * s2,
                        v1.Y * s2);
                      
        }
        //#############################################################################################################################
        public static Vector2 operator *(int s1, Vector2 v2)
        {
            return v2 * s1;
        }
        //#############################################################################################################################
        public static Vector2 operator /(Vector2 v1, int s2)
        {
            return new Vector2(
                        v1.X / s2,
                        v1.Y / s2);
        }
        //#############################################################################################################################
        public static Vector2 operator -(Vector2 v1)
        {
            return new Vector2(
                -v1.X,
                -v1.Y);
        }
        //#############################################################################################################################
        public static Vector2 operator +(Vector2 v1)
        {
            return new Vector2(
                +v1.X,
                +v1.Y);
        }
        //#############################################################################################################################
        public static bool operator <(Vector2 v1, Vector2 v2)
        {
            return v1.SumComponentSqrs() < v2.SumComponentSqrs();
        }
        //#############################################################################################################################
        public static bool operator >(Vector2 v1, Vector2 v2)
        {
            return v1.SumComponentSqrs() > v2.SumComponentSqrs();
        }
        //#############################################################################################################################
        public static bool operator <=(Vector2 v1, Vector2 v2)
        {
            return v1.SumComponentSqrs() <= v2.SumComponentSqrs();
        }
        //#############################################################################################################################
        public static bool operator >=(Vector2 v1, Vector2 v2)
        {
            return v1.SumComponentSqrs() >= v2.SumComponentSqrs();
        }
        //#############################################################################################################################
        public static bool operator ==(Vector2 v1, Vector2 v2)
        {
            return
                v1.X == v2.X &&
                v1.Y == v2.Y;
        }
        //#############################################################################################################################
        public static bool operator !=(Vector2 v1, Vector2 v2)
        {
            return !(v1 == v2);
        }
    
 
        //#############################################################################################################################
        public static int DistanceX(Vector2 v1, Vector2 v2)
        {
            return (v1.X - v2.X);
        }
        //#############################################################################################################################
        public int DistanceX(Vector2 other)
        {
            return DistanceX(this, other);
        }
        public static int DistanceY(Vector2 v1, Vector2 v2)
        {
            return (v1.Y - v2.Y);
        }
        public static int SumComponentSqrs(Vector2 v1)
        {
            Vector2 v2 = SqrtComponents(v1);
            return v2.SumComponents();
        }

        public int SumComponentSqrs()
        {
            return SumComponentSqrs(this);
        }
        public static Vector2 PowComponents(Vector2 v1, int power)
        {
            return new Vector2(
                (int)Math.Pow(v1.X, power),
                (int)Math.Pow(v1.Y, power));
        }

        public static Vector2 SqrtComponents(Vector2 v1)
        {
            return new Vector2(
                (int)Math.Sqrt(v1.X),
                (int)Math.Sqrt(v1.Y));
        }
      
        public Vector2 SqrtComponents()
        {
            return SqrtComponents(this);
        }
        

        public Vector2 PowComponents(int power)
        {
            return PowComponents(this, power);
        }

        //#############################################################################################################################
        public int DistanceY(Vector2 other)
        {
            return DistanceX(this, other);
        }
        public static int SumComponents(Vector2 v1)
        {
            return v1.X + v1.Y;
        }

        public int SumComponents()
        {
            return SumComponents(this);
        }
        //#############################################################################################################################
        public static Vector2 Max(Vector2 v1, Vector2 v2)
        {
            return v1 >= v2 ? v1 : v2;
        }
        //#############################################################################################################################
        public Vector2 Max(Vector2 other)
        {
            return Max(this, other);
        }
        //#############################################################################################################################
        public static Vector2 Min(Vector2 v1, Vector2 v2)
        {
            return v1 <= v2 ? v1 : v2;
        }

        //#############################################################################################################################
        public override string ToString()
        {
            return string.Format("{0}:{1}", this.x.ToString(), this.y.ToString());
        }
        //#############################################################################################################################
        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = this.x.GetHashCode();
                hashCode = (hashCode * 397) ^ this.y.GetHashCode();
               
                return hashCode;
            }
        }
        //#############################################################################################################################
        public override bool Equals(object other)
        {
            if (other is Vector2)
            {
                Vector2 otherVector = (Vector2)other;

                return otherVector.Equals(this);
            }
            else
            {
                return false;
            }
        }
        //#############################################################################################################################
        public bool Equals(object other, int tolerance)
        {
            if (other is Vector2)
            {
                return this.Equals((Vector2)other, tolerance);
            }
            return false;
        }
        //#############################################################################################################################
        public int CompareTo(Vector2 other)
        {
            if (this < other)
            {
                return -1;
            }

            if (this > other)
            {
                return 1;
            }

            return 0;
        }
        //#############################################################################################################################
        public int CompareTo(object other)
        {
            if (other is Vector2)
            {
                return this.CompareTo((Vector2)other);
            }


            throw new ArgumentException(NON_VECTOR_COMPARISON + "\n" + ARGUMENT_TYPE + other.GetType().ToString(), "other");
        }
        //#############################################################################################################################
        public int CompareTo(object other, int tolerance)
        {
            if (other is Vector2)
            {
                return this.CompareTo((Vector2)other, tolerance);
            }


            throw new ArgumentException(NON_VECTOR_COMPARISON + "\n" + ARGUMENT_TYPE + other.GetType().ToString(), "other");
        }
        //#############################################################################################################################
        private const string NORMALIZE_NaN = "Cannot normalize a vector when it's magnitude is NaN";
        private const string NORMALIZE_0 = "Cannot normalize a vector when it's magnitude is zero";
        private const string NORMALIZE_Inf = "Cannot normalize a vector when it's magnitude is infinite except under special conditions";
        private const string THREE_COMPONENTS = "Array must contain exactly three components , (x,y,z)";
        private const string INTERPOLATION_RANGE = "Control parameter must be a value between 0 & 1";
        private const string NON_VECTOR_COMPARISON = "Cannot compare a Vector3 to a non-Vector3";
        private const string ARGUMENT_TYPE = "The argument provided is a type of ";
        private const string ARGUMENT_VALUE = "The argument provided has a value of ";
        private const string ARGUMENT_LENGTH = "The argument provided has a length of ";
        private const string NEGATIVE_MAGNITUDE = "The magnitude of a Vector3 must be a positive value, (i.e. greater than 0)";
        private const string ORIGIN_VECTOR_MAGNITUDE = "Cannot change the magnitude of Vector3(0,0,0)";
        private const string UNIT_VECTOR = "Unit vector composing of ";
        private const string POSITIONAL_VECTOR = "Positional vector composing of  ";
        private const string MAGNITUDE = " of magnitude ";

    }
}

