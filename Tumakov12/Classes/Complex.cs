public class Complex
{
    public double Real { get; set; }
    public double Imaginary { get; set; }
    public Complex(double real, double imaginary)
    {
        Real = real;
        Imaginary = imaginary;
    }
    public static Complex operator +(Complex a, Complex b)
    {
        return new Complex(a.Real + b.Real, a.Imaginary + b.Imaginary);
    }
    public static Complex operator -(Complex a, Complex b)
    {
        return new Complex(a.Real - b.Real, a.Imaginary - b.Imaginary);
    }
    public static Complex operator *(Complex a, Complex b)
    {
        double newReal = a.Real * b.Real - a.Imaginary * b.Imaginary;
        double newImaginary = a.Real * b.Imaginary + a.Imaginary * b.Real;
        return new Complex(newReal, newImaginary);
    }
    public static bool operator ==(Complex a, Complex b)
    {
        if (a is null && b is null) return true;
        if (a is null || b is null) return false;
        return a.Real == b.Real && a.Imaginary == b.Imaginary;
    }
    public static bool operator !=(Complex a, Complex b)
    {
        return !(a == b);
    }
    public override bool Equals(object obj)
    {
        if (obj is Complex other)
            return this == other;
        return false;
    }
    public override int GetHashCode()
    {
        return HashCode.Combine(Real, Imaginary);
    }
    public override string ToString()
    {
        string sign = Imaginary >= 0 ? "+" : "";
        return $"{Real} {sign}{Imaginary}i";
    }
}