using System;

namespace TypeConversions
{
    public class Point
    {
        public int X { get; init; }

        public int Y { get; init; }

        public override string ToString()
        {
            return $"[X={X},Y={Y}]";
        }

        public static bool TryParse(string text, out Point point)
        {
            point = null;

            if (string.IsNullOrWhiteSpace(text))
            {
                return false;
            }

            string parsedText = text
                .Replace("[", string.Empty, StringComparison.OrdinalIgnoreCase)
                .Replace("]", string.Empty, StringComparison.OrdinalIgnoreCase);

            string[] parts = parsedText.Split(',', StringSplitOptions.RemoveEmptyEntries);
            if (parts.Length != 2)
            {
                return false;
            }

            string xCoord = parts[0].Replace("X=", string.Empty, StringComparison.OrdinalIgnoreCase);
            string yCoord = parts[1].Replace("Y=", string.Empty, StringComparison.OrdinalIgnoreCase);

            if (int.TryParse(xCoord, out int x) && 
                int.TryParse(yCoord, out int y))
            {
                point = new Point
                {
                    X = x,
                    Y = y
                };

                return true;
            }

            return false;
        }

        public static explicit operator Point(string text)
        {
            if (Point.TryParse(text, out Point result))
            {
                return result;
            }

            throw new InvalidCastException($"String '{text}' cannot be casted to a Point");
        }

        public static implicit operator string(Point p)
        {
            return p?.ToString() ?? string.Empty;
        }

        public static Point operator +(Point a, Point b)
        {
            return new Point
            {
                X = a.X + b.X,
                Y = a.Y + b.Y
            };
        }
    }
}
