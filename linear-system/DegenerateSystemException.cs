using System.Runtime.Serialization;

namespace linear_system
{
  [Serializable]
  internal class DegenerateSystemException : Exception
  {
    public DegenerateSystemException()
    {
    }

    public DegenerateSystemException(string? message) : base(message)
    {
    }

    public DegenerateSystemException(string? message, Exception? innerException) : base(message, innerException)
    {
    }

    protected DegenerateSystemException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }
  }
}