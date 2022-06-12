using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Linq ;

using DreamRecorder . ToolBox . Network . Dns . EDns ;

namespace DreamRecorder . ToolBox . Network . Dns
{

	/// <summary>
	///     Provides options to be used in
	///     <see cref="DnsClient">DNS client</see>
	///     for resolving queries
	/// </summary>
	public class DnsQueryOptions
	{

		/// <summary>
		///     <para>Gets or sets the recursion desired (RD) flag</para>
		///     <para>
		///         Defined in
		///         <see cref="!:http://tools.ietf.org/html/rfc1035">RFC 1035</see>
		///     </para>
		/// </summary>
		public bool IsRecursionDesired { get ; set ; }

		/// <summary>
		///     <para>Gets or sets the checking disabled (CD) flag</para>
		///     <para>
		///         Defined in
		///         <see cref="!:http://tools.ietf.org/html/rfc4035">RFC 4035</see>
		///     </para>
		/// </summary>
		public bool IsCheckingDisabled { get ; set ; }

		/// <summary>
		///     Enables or disables EDNS
		/// </summary>
		public bool IsEDnsEnabled
		{
			get => ( EDnsOptions != null ) ;
			set
			{
				if ( value && ( EDnsOptions == null ) )
				{
					EDnsOptions = new OptRecord ( ) ;
				}
				else if ( ! value )
				{
					EDnsOptions = null ;
				}
			}
		}

		/// <summary>
		///     Gets or set the OptRecord for the EDNS options
		/// </summary>
		public OptRecord EDnsOptions { get ; set ; }

		/// <summary>
		///     <para>Gets or sets the DNSSEC answer OK (DO) flag</para>
		///     <para>
		///         Defined in
		///         <see cref="!:http://tools.ietf.org/html/rfc4035">RFC 4035</see>
		///         and
		///         <see cref="!:http://tools.ietf.org/html/rfc3225">RFC 3225</see>
		///     </para>
		/// </summary>
		public bool IsDnsSecOk
		{
			get
			{
				OptRecord ednsOptions = EDnsOptions ;
				return ( ednsOptions != null ) && ednsOptions . IsDnsSecOk ;
			}
			set
			{
				OptRecord ednsOptions = EDnsOptions ;
				if ( ednsOptions == null )
				{
					if ( value )
					{
						throw new ArgumentOutOfRangeException (
																nameof ( value ) ,
																"Setting DO flag is allowed in edns messages only" ) ;
					}
				}
				else
				{
					ednsOptions . IsDnsSecOk = value ;
				}
			}
		}

	}

}
