﻿using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Linq ;

namespace DreamRecorder . ToolBox . Network . Dns . EDns
{

	/// <summary>
	///     <para>Name server ID option</para>
	///     <para>
	///         Defined in
	///         <see cref="!:http://tools.ietf.org/html/rfc5001">RFC 5001</see>
	///     </para>
	/// </summary>
	public class NsIdOption : EDnsOptionBase
	{

		internal override ushort DataLength => ( ushort )( Payload ? . Length ?? 0 ) ;

		/// <summary>
		///     Binary data of the payload
		/// </summary>
		public byte [ ] Payload { get ; private set ; }

		internal NsIdOption ( ) : base ( EDnsOptionType . NsId ) { }

		/// <summary>
		///     Creates a new instance of the NsIdOption class
		/// </summary>
		public NsIdOption ( byte [ ] payload ) : this ( ) => Payload = payload ;

		internal override void EncodeData ( byte [ ] messageData , ref int currentPosition )
		{
			DnsMessageBase . EncodeByteArray ( messageData , ref currentPosition , Payload ) ;
		}

		internal override void ParseData ( byte [ ] resultData , int startPosition , int length )
		{
			Payload = DnsMessageBase . ParseByteData ( resultData , ref startPosition , length ) ;
		}

	}

}
