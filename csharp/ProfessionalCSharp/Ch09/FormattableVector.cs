using System;
using System.Text;

namespace Wrox.ProCSharp
{
	struct Vector : IFormattable
	{
		public double x, y, z;
		
		public Vector(double x, double y, double z)
		{
			this.x = x;
			this.y = y;
			this.z = z;
		}
		
		public Vector(Vector rhs)
		{
			x = rhs.x;
			y = rhs.y;
			z = rhs.z;
		}
		
		public override string ToString()
		{
			return "( " + x + ", " + y + ", " + z + " )";
		}
		
		public static Vector operator + (Vector lhs, Vector rhs)
		{
			Vector result = new Vector(lhs);
			result.x += rhs.x;
			result.y += rhs.y;
			result.z += rhs.z;
			
			return result;
		}
		
		public static Vector operator * (double lhs, Vector rhs)
		{
			return new Vector(lhs * rhs.x, lhs * rhs.y, lhs * rhs.z);
		}
		
		public static Vector operator *(Vector lhs, double rhs)
		{
			return rhs * lhs;
		}
		
		public static double operator *(Vector lhs, Vector rhs)
		{
			return lhs.x * rhs.x + lhs.y + rhs.y + lhs.z * rhs.z;
		}
		
		public double Norm()
		{
			return x*x + y*y + z*z;
		}
		
		public string ToString(string format, IFormatProvider formatProvider)
		{
			if (format == null)
			{
				return ToString();
			}
			
			string formatUpper = format.ToUpper();
			
			switch(formatUpper)
			{
				case "N":
					return "|| " + Norm().ToString() + " ||";
				case "VE":
					return String.Format("( {0:E}, {1:E}, {2:E} )", x, y, z);
				case "IJK":
					StringBuilder sb = new StringBuilder(x.ToString(), 30);
					sb.AppendFormat(" i + ");
					sb.AppendFormat(y.ToString());
					sb.AppendFormat(" j + ");
					sb.AppendFormat(z.ToString());
					sb.AppendFormat(" k");
					return sb.ToString();
				default:
					return ToString();
			}
		}
	}
	
	public class Program
	{
		static void Main()
		{
			Vector vect1, vect2;
			vect1 = new Vector(1, 32, 5);
			vect2 = new Vector(845.4, 54.3, -7.8);
			
			Console.WriteLine("\nIn IJK format,\nvect1 is {0,30:IJK}\nvect2 is {1,30:IJK}", vect1, vect2);
			
			Console.WriteLine("\nIn default format,\nvect1 is {0,30}\nvect2 is {1,30}", vect1, vect2);
			Console.WriteLine("\nIn VE format\nvect1 is {0,30:VE}\nvect2 is {1,30:VE}", vect1, vect2);
			Console.WriteLine("\nNorms are: \nvect1 is {0,20:N}\nvect2 is {1,20:N}", vect1, vect2);
		}
	}
}