using System;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;

namespace Utils._Verify
{
    public static class Verify
    {
#pragma warning disable CA2208 // Instantiate argument exceptions correctly
        [DebuggerHidden()]
        public static void NonNullArg<T>([NotNull] T? o, string? name = null, string? message = null) where T : class
        {
            if (o == null)
            {
                if (name == null)
                {
                    throw new ArgumentNullException();
                }
                else if (message == null)
                {
                    throw new ArgumentNullException(name);
                }
                else
                {
                    throw new ArgumentNullException(name, message);
                }
            }
        }

        [DebuggerHidden()]
        public static void RangeArg<T>(T start, T v, T end, string? name = null, string? message = null) where T : IComparable<T>
        {
            if (start.CompareTo(v) > 0 || v.CompareTo(end) > 0)
            {
                if (name == null)
                {
                    throw new ArgumentOutOfRangeException();
                }
                else if (message == null)
                {
                    throw new ArgumentOutOfRangeException(name, v, string.Format("Argument must be between '{0}' and '{1}'.", start, end));
                }
                else
                {
                    throw new ArgumentOutOfRangeException(name, v, message);
                }
            }
        }

        [DebuggerHidden()]
        public static void TrueArg([DoesNotReturnIf(false)] bool t, string? name = null, string? message = null)
        {
            if (!t)
            {
                if (name == null & message == null)
                {
                    throw new ArgumentException();
                }
                else
                {
                    throw new ArgumentException(message, name);
                }
            }
        }

        [DebuggerHidden()]
        public static void FalseArg([DoesNotReturnIf(true)] bool t, string? name = null, string? message = null)
        {
            if (t)
            {
                if (name == null & message == null)
                {
                    throw new ArgumentException();
                }
                else
                {
                    throw new ArgumentException(message, name);
                }
            }
        }

        [DebuggerHidden()]
        [DoesNotReturn]
        public static ArgumentException FailArg(string? name = null, string? message = null)
        {
            if (name == null & message == null)
            {
                throw new ArgumentException();
            }
            else
            {
                throw new ArgumentException(message, name);
            }
        }
#pragma warning restore CA2208 // Instantiate argument exceptions correctly

        [DebuggerHidden()]
        public static void NonNull<T>([NotNull] T? o, string? name = null) where T : class
        {
            if (o == null)
            {
                if (name == null)
                {
                    throw new NullReferenceException(string.Format("Object reference '{0}' not set to an instance of an object.", name));
                }
                else
                {
                    throw new NullReferenceException();
                }
            }
        }

        [DebuggerHidden()]
        public static void True([DoesNotReturnIf(false)] bool t, string? message = null)
        {
            if (!t)
            {
                throw new InvalidOperationException(message);
            }
        }

        [DebuggerHidden()]
        public static void False([DoesNotReturnIf(true)] bool t, string? message = null)
        {
            if (t)
            {
                throw new InvalidOperationException(message);
            }
        }

        [DebuggerHidden()]
        [DoesNotReturn]
        public static InvalidOperationException Fail(string? message = null)
        {
            throw new InvalidOperationException(message);
        }
    }

    public static class Assert
    {
        [DebuggerHidden()]
        public static void NonNull<T>([NotNull] T? o, string? name = null) where T : class
        {
            if (o == null)
            {
                if (name != null)
                {
                    Fail(string.Format("Object reference '{0}' not set to an instance of an object.", name));
                }
                else
                {
                    Fail("Object reference not set to an instance of an object.");
                }
            }
        }

        [DebuggerHidden()]
        public static void True([DoesNotReturnIf(false)] bool t, string? message = null)
        {
            if (!t)
            {
                Fail(message);
            }
        }

        [DebuggerHidden()]
        public static void False([DoesNotReturnIf(true)] bool t, string? message = null)
        {
            if (t)
            {
                Fail(message);
            }
        }

        [DebuggerHidden()]
        [DoesNotReturn]
        public static AssertionException Fail(string? message = null)
        {
            throw new AssertionException(message);
        }
    }

    public class AssertionException : Exception
    {
        public AssertionException()
        {
        }

        public AssertionException(string? message) : base(message)
        {
        }

        public AssertionException(string? message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
