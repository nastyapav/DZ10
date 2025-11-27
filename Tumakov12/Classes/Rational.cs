public class Rational
{
    public int Chislitel { get; set; }
    public int Znamenatel { get; set; }
    public Rational(int chislitel, int znamenatel)
    {
        if (znamenatel == 0)
            throw new ArgumentException("Знаменатель не может быть 0");
        Chislitel = chislitel;
        Znamenatel = znamenatel;
        Simplify();
    }
    private void Simplify()
    {
        //GCD обозначила наибольший общ.делитель
        int gcd = GCD(Math.Abs(Chislitel), Math.Abs(Znamenatel));
        Chislitel = Chislitel / gcd;
        Znamenatel = Znamenatel / gcd;
        if (Znamenatel < 0)
        {
            Chislitel = -Chislitel;
            Znamenatel = -Znamenatel;
        }
    }
    private int GCD(int a, int b)
    {
        while (b != 0)
        {
            int temp = b;
            b = a % b;
            a = temp;
        }
        return a;
    }
    public static bool operator ==(Rational a, Rational b)
    {
        if (a is null && b is null) return true;
        if (a is null || b is null) return false;
        return a.Chislitel * b.Znamenatel == b.Chislitel * a.Znamenatel;
    }
    public static bool operator !=(Rational a, Rational b)
    {
        return !(a == b);
    }
    public static bool operator <(Rational a, Rational b)
    {
        return a.Chislitel * b.Znamenatel < b.Chislitel * a.Znamenatel;
    }
    public static bool operator >(Rational a, Rational b)
    {
        return a.Chislitel * b.Znamenatel > b.Chislitel * a.Znamenatel;
    }
    public static bool operator <=(Rational a, Rational b)
    {
        return a < b || a == b;
    }
    public static bool operator >=(Rational a, Rational b)
    {
        return a > b || a == b;
    }
    public static Rational operator +(Rational a, Rational b)
    {
        int chisl = a.Chislitel * b.Znamenatel + b.Chislitel * a.Znamenatel;
        int znam = a.Znamenatel * b.Znamenatel;
        return new Rational(chisl, znam);
    }
    public static Rational operator -(Rational a, Rational b)
    {
        int chisl = a.Chislitel * b.Znamenatel - b.Chislitel * a.Znamenatel;
        int znam = a.Znamenatel * b.Znamenatel;
        return new Rational(chisl, znam);
    }
    public static Rational operator *(Rational a, Rational b)
    {
        return new Rational(a.Chislitel * b.Chislitel, a.Znamenatel * b.Znamenatel);
    }
    public static Rational operator /(Rational a, Rational b)
    {
        if (b.Chislitel == 0)
            throw new DivideByZeroException();
        return new Rational(a.Chislitel * b.Znamenatel, a.Znamenatel * b.Chislitel);
    }
    public static Rational operator %(Rational a, Rational b)
    {
        if (b.Chislitel == 0)
            throw new DivideByZeroException();
        double aVal = (double)a.Chislitel / a.Znamenatel;
        double bVal = (double)b.Chislitel / b.Znamenatel;
        double result = aVal % bVal;
        return new Rational((int)(result * 1000), 1000);
    }
    public static Rational operator ++(Rational r)
    {
        return r + new Rational(1, 1);
    }
    public static Rational operator --(Rational r)
    {
        return r - new Rational(1, 1);
    }
    //implicit и explicit для неявного и явного преобразований
    public static implicit operator float(Rational r)
    {
        return (float)r.Chislitel / r.Znamenatel;
    }
    public static implicit operator int(Rational r)
    {
        return (int)Math.Round((double)r.Chislitel / r.Znamenatel);
    }
    public static explicit operator Rational(float value)
    {
        int multiplier = 10000;
        int chisl = (int)(value * multiplier);
        return new Rational(chisl, multiplier);
    }
    public override string ToString()
    {
        return $"{Chislitel}/{Znamenatel}";
    }
}