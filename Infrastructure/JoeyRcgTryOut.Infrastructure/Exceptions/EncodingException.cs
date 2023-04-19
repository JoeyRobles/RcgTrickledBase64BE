namespace JoeyRcgTryOut.Infrastructure.Exceptions
{

	[Serializable]
	public class EncodingException : Exception
	{
		public EncodingException() { }
		public EncodingException(string message) : base(message) { }
		public EncodingException(string message, Exception inner) : base(message, inner) { }
		protected EncodingException(
		  System.Runtime.Serialization.SerializationInfo info,
		  System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
	}
}
